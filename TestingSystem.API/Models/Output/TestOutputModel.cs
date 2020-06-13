using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class TestOutputModel
    {
        //модель с названием тестов

        public int ID { get; set; }
        public string Name { get; set; }

        
        //public TimeSpan DurationTime { get; set; }
        //public byte SuccessScore { get; set; }
        //public int QuestionNumber { get; set; }
        //public List<QuestionModel> Questions { get; set; }
        //public List<string> Tags { get; set; }
        
    }
}
