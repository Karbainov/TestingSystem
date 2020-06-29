using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Statistics.Models
{
    public class AttemptQuestionAnswerAllIdsModel
    {
        public int AttemptId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int TestId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
    }
}
