using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

using TestingSystem;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using TestingSystem.API.Models.Input;
using TestingSystem.API.Models;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.API.Models.Output;

namespace TestingSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        [HttpGet]
        public UserWithLoginOutputModel get([FromBody] LoginInputModel log)
        {
            Mapper mapper = new Mapper();
            return mapper.ConvertUserByLoginDTOToListUserWithLoginOutputModel(log.Login);
        }

        [HttpPost]
        public IActionResult Auth([FromBody] AuthorizeInputModel auth)
        {
            ClaimsIdentity identity = GetIdentity(auth.Login, auth.Password,auth.Role);
            if (identity != null)
            {
                DateTime now = DateTime.UtcNow;
                JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: Models.TokenOptions.ISSUER,
                    audience: Models.TokenOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(Models.TokenOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(Models.TokenOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                    );
               
                var response = new
                {
                    access_token = new JwtSecurityTokenHandler().WriteToken(jwt),
                    login = auth.Login
                };
                return Ok(response);
            }
            else
            {
                return null;
            }
        }

        private ClaimsIdentity GetIdentity(string login, string password,string role)
        {
            Mapper mapper = new Mapper();
            UserByLoginOutputModel user = mapper.ConvertUserByLoginDTOToListUserByLoginOutputModel(login);

            if (user != null)
            {
                if (user.Role.Contains(role)==true && user.Password==password)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                    new Claim(ClaimsIdentity.DefaultNameClaimType,user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType,role)
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    return claimsIdentity;
                }
                else
                {
                    return null;

                }
            }
            return null;
        }

    }
}
