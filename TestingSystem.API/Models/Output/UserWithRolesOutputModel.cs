using System;
using System.Collections.Generic;
namespace TestingSystem.API.Models.Output
{
    public class UserWithRolesOutputModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<string> Roles { get; set; }

        public UserWithRolesOutputModel(int id, string firstname, string lastname, DateTime birthdate, string login, string password, string email, string phone, List<string> roles)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
            Login = login;
            Password = password;
            Email = email;
            Phone = phone;
            Roles = roles;

        }

        public UserWithRolesOutputModel()
        {
        }
    }
}
