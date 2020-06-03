using System;
namespace TestingSystem.Data.DTO
{
    public class UserWithRoleDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RoleID { get; set; }

        public UserWithRoleDTO(int id, string firstname, string lastname, DateTime birthdate, string login, string password, string email, string phone, int roleID)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
            Login = login;
            Password = password;
            Email = email;
            Phone = phone;
            RoleID = roleID;

        }
      

        public UserWithRoleDTO()
        {
        }
    }
}
