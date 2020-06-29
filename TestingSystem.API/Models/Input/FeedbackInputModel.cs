using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Input
{
    public class FeedbackInputModel
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string Message { get; set; }
        
        public FeedbackInputModel()
        {
        }

        public FeedbackInputModel(int userId, int questionId, string message)
        {
            this.UserId = userId;
            this.QuestionId = questionId;
            this.Message = message;
        }
    }
}
