using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class FeedbackDTO
    {
        public int ID { get; set; }
        public int userId { get; set; }
        public int questionId { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public Boolean Processed { get; set; }

        public FeedbackDTO()
        {
        }

        public FeedbackDTO(int Id, int userId, int questionId, string message, DateTime date, Boolean processed)
        {
            this.ID = Id;
            this.userId = userId;
            this.questionId = questionId;
            this.Message = message;
            this.DateTime = date;
            this.Processed = processed;
        }
    }
}
