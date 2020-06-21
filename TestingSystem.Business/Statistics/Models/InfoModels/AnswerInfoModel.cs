using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Statistics.Models
{
    public class AnswerInfoModel
    {
        public int QuestionID { get; set; }
        public string Value { get; set; }
        public bool Correct { get; set; }
    }
}
