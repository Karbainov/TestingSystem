using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class UserIdDateIdDTO
    {
        public int UserID { get; set; }
        public DateTime DateTime { get; set; }

        public UserIdDateIdDTO()
        {
        }

        public UserIdDateIdDTO(int userId, DateTime date)
        {
            UserID = userId;
            DateTime = date;
        }
    }
}
