using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int questionId { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
        public Boolean processed { get; set; }

        public FeedbackDTO()
        {
        }

        public FeedbackDTO(int Id, int userId, int questionId, string message, DateTime date, Boolean processed)
        {
            this.Id = Id;
            this.userId = userId;
            this.questionId = questionId;
            this.message = message;
            this.date = date;
            this.processed = processed;
        }
    }
}
