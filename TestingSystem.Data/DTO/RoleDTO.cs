using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    class RoleDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public RoleDTO(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public RoleDTO()
        { }
    }
}
