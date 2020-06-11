using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class QuestionIdOutput
    {
        public int QuestionId { get; set; }        
        public string QuestionValue { get; set; }        
        //?public byte AnswersCount { get; set; }
        public byte Weight { get; set; }

        public string TypeName { get; set; }

        public int AnswerId { get; set; }        
        public string AnswerValue { get; set; }
        public bool Correct { get; set; }
    }
}
