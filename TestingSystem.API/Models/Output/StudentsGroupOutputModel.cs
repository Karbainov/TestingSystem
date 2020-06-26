using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class StudentsGroupOutputModel
    {
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public StudentsGroupOutputModel(int? id, string firstname, string lastname, string email, string phone)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Phone = phone;

        }
        public StudentsGroupOutputModel()
        {
        }
    }
}
