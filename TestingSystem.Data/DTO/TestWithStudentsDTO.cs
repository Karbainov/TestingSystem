using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class TestWithStudentsDTO
    {
        public TestDTO Test { get; set; }
        public List<UserDTO> Students { get; set; }
    }
}
