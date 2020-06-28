using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Statistics.Models
{
   public class AnswerAttemptsInfoModel
    {
        public int AnswersStudentId { get; set; }
        public List<int> AttemptId { get; set; }
    }
}
