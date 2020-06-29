using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class UserPositionDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<RoleIdDTO> Roles { get; set; }

        public UserPositionDTO()
        {

        }

        public UserPositionDTO(int id, string firstName, string lastName, DateTime birthdate, string login, string password, string email, string phone, List<RoleIdDTO> roles)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthdate;
            this.Login = login;
            this.Password = password;
            this.Email = email;
            this.Phone = phone;
            this.Roles = Roles;
        }
    }
}
