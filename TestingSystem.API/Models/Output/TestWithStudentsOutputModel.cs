using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class TestWithStudentsOutputModel
    {
        public TestOutputModel Test { get; set; }
        public List<UserOutputModel> Students {get;set;}
    }
}
