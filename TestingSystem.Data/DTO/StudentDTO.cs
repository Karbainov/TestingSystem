using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class StudentDTO
    {
        public int IDGroup { get; set; }
        public int StudentID { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public DateTime StudentBirthDate { get; set; }
        public string StudentLogin { get; set; }
        public string StudentPassword { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhone { get; set; }
    }
}
