using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Input
{
    public class AnswerWithoutIDInputModel
    {
        public int QuestionID { get; set; }
        public string Value { get; set; }
    }
}
