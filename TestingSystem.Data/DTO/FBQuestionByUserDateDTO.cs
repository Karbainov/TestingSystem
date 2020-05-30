using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class FBQuestionByUserDateDTO
    {
        public int userId { get; set; }
        public DateTime date { get; set; }
        public string message { get; set; }
        public string value { get; set; }

        public FBQuestionByUserDateDTO()
        {
        }

        public FBQuestionByUserDateDTO(int userId, DateTime date)
        {
            this.userId = userId;
            this.date = date;
        }
    }
}
