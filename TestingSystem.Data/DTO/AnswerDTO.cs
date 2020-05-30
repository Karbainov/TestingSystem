using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    class AnswerDTO
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Value { get; set; }
        public bool Correct { get; set; }
        public AnswerDTO (int _id,int _questionID,string _value,bool _correct)
        {
            ID = _id;
            QuestionID = _questionID;
            Value = _value;
            Correct = _correct;
        }
        public AnswerDTO()
        { }
    }
}
