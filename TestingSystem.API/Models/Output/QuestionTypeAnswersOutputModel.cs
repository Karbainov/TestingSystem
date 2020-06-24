using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class QuestionTypeAnswersOutputModel
    {
        public int TypeId { get; set; }
        public int Id { get; set; }
        public string Value { get; set; }
        
        public QuestionTypeAnswersOutputModel(int typeId, int answerId, string value)
        {
            TypeId = typeId;
            Id = answerId;
            Value = value;
        }
    }
}