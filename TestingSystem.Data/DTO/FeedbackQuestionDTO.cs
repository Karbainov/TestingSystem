using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class FeedbackQuestionDTO
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TestName { get; set; }
        public string Question { get; set; }       
        public Boolean Processed { get; set; }

        public FeedbackQuestionDTO()
        {
        }

        public FeedbackQuestionDTO(int Id, string message, DateTime date, string firstname, string lastname, string testname, string question, Boolean processed)
        {
            ID = Id;            
            Message = message;
            DateTime = date;
            FirstName = firstname;
            LastName = lastname;
            TestName = testname;
            Question = question;
            Processed = processed;
        }
    }
}
