using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class StudentDTO
    {
        public int SID { get; set; }
        public string SFirstName { get; set; }
        public string SLastName { get; set; }
        public DateTime SBirthDate { get; set; }
        public string SLogin { get; set; }
        public string SPassword { get; set; }
        public string SEmail { get; set; }
        public string SPhone { get; set; }
    }
}
