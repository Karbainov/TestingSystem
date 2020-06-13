using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class RoleIdDTO
    {
        public int RoleID { get; set; }
        public string Name { get; set; }

        public RoleIdDTO(int id, string name)
        {
            RoleID = id;
            Name = name;
        }
        public RoleIdDTO()
        { }
    }
}
