using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class TestAttemptOutputModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TimeSpan DurationTime { get; set; }
        public int SuccessScore { get; set; }
        public int AttemptCount { get; set; }
        public int BestResult { get; set; }
    }
}
