using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class TestIdOutput
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public TimeSpan DurationTime { get; set; }

        public List<?> questions;
        //public int QuestionId { get; set; }        
        //public string QuestionValue { get; set; }        
        //public byte Weight { get; set; }

        public List<?> answers;
        //public int AnswerId { get; set; }        
        //public string AnswerValue { get; set; }
        //public bool Correct { get; set; }

        public List<?> tags;
    }
}
