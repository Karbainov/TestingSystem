using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class TypeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public TypeDTO()
        {

        }

        public TypeDTO(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
