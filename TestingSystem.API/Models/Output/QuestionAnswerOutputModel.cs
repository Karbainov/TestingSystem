using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class QuestionAnswerOutputModel
    {
        public int ID { get; set; }
        public string QValue { get; set; }
        public string AValue { get; set; }
        public bool Correct { get; set; }
    }
}
