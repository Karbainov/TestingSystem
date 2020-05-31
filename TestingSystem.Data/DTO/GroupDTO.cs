using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class GroupDTO
        {
            public int id { get; set; }
            public string name { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }

            public GroupDTO()
            {

            }

            public GroupDTO(int id, string name, DateTime startDate, DateTime endDate)
            {
                this.id = id;
                this.name = name;
                this.startDate = startDate;
                this.endDate = endDate;
            }

        }
}
