using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    class TeacherDTO
    {
        public int TID { get; set; }
        public string TFirstName { get; set; }
        public string TLastName { get; set; }
        public DateTime TBirthDate { get; set; }
        public string TLogin { get; set; }
        public string TPassword { get; set; }
        public string TEmail { get; set; }
        public string TPhone { get; set; }
    }
}
