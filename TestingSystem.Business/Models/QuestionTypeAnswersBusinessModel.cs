using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Models
{
    public class QuestionTypeAnswersBusinessModel
    {
        public int TypeId { get; set; }
        public int Id { get; set; }
        public string Value { get; set; }
        
        public QuestionTypeAnswersBusinessModel(int typeId, int answerId, string value)
        {
            TypeId = typeId;
            Id = answerId;
            Value = value;
        }
    }
}