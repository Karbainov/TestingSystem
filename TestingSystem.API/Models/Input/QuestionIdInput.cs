using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Input
{
    public class QuestionIdInput
    {        
        public string QuestionValue { get; set; }
        //?public byte AnswersCount { get; set; }
        public byte Weight { get; set; }

        public string TypeName { get; set; }
        
        public string AnswerValue { get; set; }
        public bool Correct { get; set; }
    }
}
