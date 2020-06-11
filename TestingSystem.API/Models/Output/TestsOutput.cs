using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class TestsOutput
    {
        public int TestId { get; set; }
        public string TestName { get; set; }

        public int FeedbackId { get; set; }        
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public Boolean Processed { get; set; }
    }
}
