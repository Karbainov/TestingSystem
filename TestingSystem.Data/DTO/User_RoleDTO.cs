using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class User_RoleDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public User_RoleDTO(int id, int userID, int roleID)
        {
            ID = id;
            UserID = userID;
            RoleID = roleID;
        }
        public User_RoleDTO()
        {

        }
    }
}
