using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class AnswerOutputModel
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Value { get; set; }
        public bool? Correct { get; set; }
        public double? PercentageOfPeopleChoosingAnswer { get; set; }
    }
}
