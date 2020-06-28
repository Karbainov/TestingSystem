using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class GroupTestsAndResultsOutputModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TimeSpan? DurationTime { get; set; }
        public byte? SuccessScore { get; set; }
        public double Result { get; set; }
    }
}
