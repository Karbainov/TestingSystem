using System;
namespace TestingSystem.API.Models.Input
{
    public class TestGroupInputModel
    {
        

        public int groupId { get; set; }
        public int testId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    
        public TestGroupInputModel()
        {

        }

        public TestGroupInputModel(int groupId, int testId, DateTime startDate, DateTime endDate)
        {

            this.groupId = groupId;
            this.testId = testId;
            this.startDate = startDate;
            this.endDate = endDate;

        }
    }
    
}
