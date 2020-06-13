using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class TestQuestionsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TimeSpan DurationTime { get; set; }
        public byte SuccessScore { get; set; }
        public int QuestionNumber { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public byte Weight { get; set; }

        public TestQuestionsDTO(int Id, string name, TimeSpan duration, byte score, int questionNumber, int questionId, string question, byte weight)
        {
            ID = Id;
            Name = name;
            DurationTime = duration;
            SuccessScore = score;
            QuestionNumber = questionNumber;
            QuestionId = questionId;
            Question = question;
            Weight = weight;
        }
    }
}
