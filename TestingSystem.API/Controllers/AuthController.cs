using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public class AuthController : Controller
    {
        [HttpGet]
        public AuthInputModel get()
        {
            return new AuthInputModel() { Login = "", Password = "" };
        }

        [HttpPost]
        public IActionResult Auth([FromBody]AuthInputModel auth)
        {
            ClaimsIdentity identity = GetIdentity(auth.Login, auth.Password);
            if(identity!=null)
            {
                DateTime now = DateTime.UtcNow;
                JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: Models.TokenOptions.ISSUER,
                    audience: Models.TokenOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(Models.TokenOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(Models.TokenOptions.GetSymmetricSecurityKey(),SecurityAlgorithms.HmacSha256)
                    ) ;
                var response = new
                {
                    access_token = new JwtSecurityTokenHandler().WriteToken(jwt),
                    login = auth.Login
                };
                return Ok(response);
            }
            else
            {
                return BadRequest("Введена неверная пара логин-пароль");
            }
        }

        private ClaimsIdentity GetIdentity(string login,string password)
        {
            Mapper mapper = new Mapper();
            List<UserByLoginOutputModel> aa = mapper.ConvertUserByLoginDTOToListUserByLoginOutputModel(login);
            UserByLoginOutputModel user = aa.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user == null)
            {
                return null;
            }
            else
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType,user.Login),//
                    new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role)//
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;

            }
        }
    }
}
