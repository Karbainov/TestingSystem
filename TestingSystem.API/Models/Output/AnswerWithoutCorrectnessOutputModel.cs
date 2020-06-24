using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class AnswerWithoutCorrectnessOutputModel
    {
        public int ID { get; set; }

        public int QuestionId { get; set; }

        public string Value { get; set; }
    }
}
