using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class FeedbackByDateDTO
    {


        //не нужна
        public DateTime DateTime { get; set; }
        public string QuestionValue { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Message { get; set; }

        public FeedbackByDateDTO()
        {

        }

        public FeedbackByDateDTO(DateTime dateTime, string questionValue, string userFirstName, string userLastName, string message)
        {
            DateTime = dateTime;
            QuestionValue = questionValue;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            Message = message;
        }
    }
}
