using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;
using Dapper;
using System.Linq;
using System.Data;

namespace TestingSystem.Data.DTO
{
    public class UserByLoginDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public UserByLoginDTO(string firstname, string lastname, DateTime birthdate, string login, string password, string email, string phone, string role)
        {
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
            Login = login;
            Password = password;
            Email = email;
            Phone = phone;
            Role = role;
        }
        public UserByLoginDTO()
        { }
    }
}
