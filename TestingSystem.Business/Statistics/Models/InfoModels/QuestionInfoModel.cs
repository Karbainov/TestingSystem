using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Statistics.Models
{
    public class QuestionInfoModel
    {
        public int TestId { get; set; }
        public string Value { get; set; }
        public int TypeId { get; set; }
        public byte AnswersCount { get; set; }
        public byte Weight { get; set; }
        public List<int> AnswersId { get; set; }
        public List<int> CorrectId { get; set; }   //создать список с индексом корректных ответов
    }
}
