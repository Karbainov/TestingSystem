using System;
namespace TestingSystem.API.Models.Input
{
    public class TestGroupInputModel
    {
        

        public int? groupId { get; set; }
        public int? testId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    
        public TestGroupInputModel()
        {

        }

        public TestGroupInputModel(int groupId, int testId, string startDate, string endDate)
        {

            this.groupId = groupId;
            this.testId = testId;
            this.startDate = startDate;
            this.endDate = endDate;

        }
    }
    
}
