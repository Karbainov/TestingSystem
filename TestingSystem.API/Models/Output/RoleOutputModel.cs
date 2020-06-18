using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class RoleOutputModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public RoleOutputModel(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public RoleOutputModel()
        { }
    }
}