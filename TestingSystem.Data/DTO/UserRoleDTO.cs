using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class UserRoleDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public UserRoleDTO(int id, int userID, int roleID)
        {
            this.ID = id;
            this.UserID = userID;
            this.RoleID = roleID;
        }
        public UserRoleDTO()
        {

        }
    }
}
