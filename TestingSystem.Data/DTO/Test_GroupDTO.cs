using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class TestGroupDTO
    {
        public int id { get; set; }
        public int groupId { get; set; }
        public int testId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public TestGroupDTO()
        {

        }

        public TestGroupDTO(int id, int groupId, int testId, DateTime startDate, DateTime endDate)
        {
            this.id = id;
            this.groupId = groupId;
            this.testId =testId;
            this.startDate = startDate;
            this.endDate = endDate;

        }

    }
}
