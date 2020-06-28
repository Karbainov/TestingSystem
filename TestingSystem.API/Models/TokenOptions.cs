using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace TestingSystem.API.Models
{
    public class TokenOptions
    {
        public const string ISSUER = "80.78.240.16";
        public const string AUDIENCE = "TestingSystem";//название проекта 
        const string KEY = "itdevspbitdevspb";//16 знаков 
        public const int LIFETIME = 300;//в минутах 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
