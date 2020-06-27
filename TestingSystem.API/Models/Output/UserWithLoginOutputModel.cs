using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class UserWithLoginOutputModel
    {
        public string Login { get; set; }
        public List<string> Role { get; set; }

    }
}
