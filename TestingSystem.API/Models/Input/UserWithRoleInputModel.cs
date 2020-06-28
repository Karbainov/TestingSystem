using System;

namespace TestingSystem.API.Models.Input
{
    public class UserWithRoleInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }

        public UserWithRoleInputModel(string firstname, string lastname, DateTime birthdate, string login, string password, string email, string phone, int roleId)
        {
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
            Login = login;
            Password = password;
            Email = email;
            Phone = phone;
            RoleId = roleId;
        }
        public UserWithRoleInputModel()
        {
        }
    }
}