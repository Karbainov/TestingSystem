using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class QuestionOutputModel
    {
        public int ID { get; set; }
        public int TestID { get; set; }
        public string Value { get; set; }
        public Nullable<int> AnswerCount { get; set; }
        public Nullable<QuestionType> Type { get; set; }
        public Nullable<int> Weight { get; set; }
        public List<AnswerOutputModel> Answers { get; set; }
    }

    public enum QuestionType { SingleAnswer, MultipleAnswer, TextAnswer }
}
