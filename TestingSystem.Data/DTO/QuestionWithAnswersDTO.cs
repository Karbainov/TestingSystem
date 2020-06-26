using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class QuestionWithAnswersDTO
    {
        public int IDQuestion { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public int AnswersCount { get; set; }
        public int Weight { get; set; }
        public List<AnswerDTO> answers { get; set; }
    }
}
