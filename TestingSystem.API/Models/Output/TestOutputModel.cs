using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class TestOutputModel
    {       
        public int ID { get; set; }
        public string Name { get; set; }        
        public TimeSpan? DurationTime { get; set; }
        public byte? SuccessScore { get; set; }
        public int? QuestionNumber { get; set; }
        public double AverageResult { get; set; }
        public int Passed { get; set; }
        public int Failed { get; set; }
        public double SuccessRate { get; set; }

        public List<QuestionOutputModel> Questions { get; set; }
        public List<TagOutputModel> Tags { get; set; }        
    }
}
