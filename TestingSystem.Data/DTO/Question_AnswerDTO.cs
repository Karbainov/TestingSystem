using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    class Question_AnswerDTO
    {
        public string Question_Value { get; set; }
        public string Answer_Value { get; set; }
        public Question_AnswerDTO(string _question_Value, string _answer_Value)
        {
            Question_Value = _question_Value;
            Answer_Value = _answer_Value;
        }
        public Question_AnswerDTO()
        { }
    }
}
