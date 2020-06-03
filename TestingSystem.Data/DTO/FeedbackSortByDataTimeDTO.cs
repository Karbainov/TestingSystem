using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class FeedbackSortByDataTimeDTO
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
         public FeedbackSortByDataTimeDTO (int _id,string _value,string _message,DateTime _dataTime,string _firstName,string _lastName)
        {
            Id = _id;
            Value = _value;
            Message = _message;
            DateTime = _dataTime;
            FirstName = _firstName;
            LastName = _lastName;
        }
        public FeedbackSortByDataTimeDTO()
        {

        }
    }
}
