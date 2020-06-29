using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class FeedbackQuestionOutputModel
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TestName { get; set; }
        public string Question { get; set; }
        public Boolean Processed { get; set; }

        public List<AnswerOutputModel> Answers { get; set; }
    }
}
