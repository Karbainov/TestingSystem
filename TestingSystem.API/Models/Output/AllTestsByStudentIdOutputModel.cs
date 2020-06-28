using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class AllTestsByStudentIdOutputModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameTest { get; set; }
        public int NumberOfAttempts { get; set; }
        public int MaxResult { get; set; }
    }
}
