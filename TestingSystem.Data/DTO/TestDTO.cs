using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class TestDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<TimeSpan> DurationTime { get; set; }
        public Nullable<byte> SuccessScore { get; set; }        
        public Nullable<int> QuestionNumber { get; set; }        

        public TestDTO()
        {
        }

        public TestDTO(int Id, string name, TimeSpan duration, byte score, int questionNumber)
        {
            ID = Id;
            Name = name;
            DurationTime = duration;
            SuccessScore = score;
            QuestionNumber = questionNumber;
        }

        public TestDTO(int Id, TimeSpan duration,  int questionNumber)
        {
            ID = Id;
            DurationTime = duration;
            QuestionNumber = questionNumber;
        }
    }
}
