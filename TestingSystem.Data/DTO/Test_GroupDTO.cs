using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class Test_GroupDTO
    {
        public int id { get; set; }
        public int idGroup { get; set; }
        public int idTest { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public Test_GroupDTO()
        {

        }

        public Test_GroupDTO(int id, int idGroup, int idTest, DateTime startDate, DateTime endDate)
        {
            this.id = id;
            this.idGroup = idGroup;
            this.idTest = idTest;
            this.startDate = startDate;
            this.endDate = endDate;

        }

    }
}
