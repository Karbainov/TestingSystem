using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class QuestionWithListAnswersOutputModel
    {
        public int Id { get; set; }

        public string Value { get; set; }
        public int TypeID { get; set; }
        
        public byte Weight { get; set; }

        public List<AnswerWithoutCorrectnessOutputModel> Answers { get; set; }



    }
}
