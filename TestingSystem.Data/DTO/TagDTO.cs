using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class TagDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public TagDTO() { }
        public TagDTO(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
