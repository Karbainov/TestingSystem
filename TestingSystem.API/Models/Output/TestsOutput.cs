using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class TestsOutput
    {
        public List<?> tests; 
        //public int TestId { get; set; }
        //public string TestName { get; set; }

        public Boolean TestsOrFeedbacks { get; set; }

        public List<?> feedbacks;
        //public int FeedbackId { get; set; }        
        //public string Message { get; set; }
        //public DateTime DateTime { get; set; }
        //public Boolean Processed { get; set; }
    }
}
