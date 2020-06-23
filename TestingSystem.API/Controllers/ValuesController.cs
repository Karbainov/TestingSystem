using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstToken.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class vController : Controller
    {
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public string geta()
        {
            return "ты админ";
        }


        [Authorize(Roles = "Student,Admin")]
        [HttpGet("s")]
        public string gets()
        {
            return "ты студент";
        }


        [Authorize]
        [HttpGet("www")]
        public string www()
        {
            return "ты студент";
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("t")]
        public string gett()
        {
            return "ты преп";
        }

        [Authorize(Roles = "Test")]
        [HttpGet("test")]
        public string gettt()
        {
            return "ты молодец ";
        }
    }
}
