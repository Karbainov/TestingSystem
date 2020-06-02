using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class UserIdDateForFeedbackDTO
    {
        public int UserID { get; set; }
        public DateTime DateTime { get; set; }

        public UserIdDateForFeedbackDTO()
        {
        }

        public UserIdDateForFeedbackDTO(int userId, DateTime date)
        {
            UserID = userId;
            DateTime = date;
        }
    }
}
