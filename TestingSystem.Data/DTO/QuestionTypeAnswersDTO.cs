using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class QuestionTypeAnswersDTO
    {
        public int TypeId { get; set; }
        public int Id { get; set; }
        public string Value { get; set; }

        public QuestionTypeAnswersDTO(int typeId, int answerId, string value)
        {
            TypeId = typeId;
            Id = answerId;
            Value = value;
        }


        public QuestionTypeAnswersDTO()
        {
            
        }
    }
}