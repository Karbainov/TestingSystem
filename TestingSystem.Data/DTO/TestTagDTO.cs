using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class TestTagDTO
    {
        public int ID { get; set; }
        public int TestID { get; set; }
        public int TagID { get; set; }

        public TestTagDTO() { }

        public TestTagDTO(int id, int testId, int tagId)
        {
            ID = id;
            TestID = testId;
            TagID = tagId;
        }
    }
}
