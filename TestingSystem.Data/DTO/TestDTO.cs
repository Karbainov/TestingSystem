using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class TestDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TimeSpan DurationTime { get; set; }
        public int SuccessScore { get; set; }
        public Boolean IsDeleted { get; set; }

        public TestDTO()
        {
        }

        public TestDTO(int Id)
        {
            ID = Id;
        }

        public TestDTO(int Id, string name, TimeSpan duration, int score, Boolean isDeleted)
        {
            ID = Id;
            Name = name;
            DurationTime = duration;
            SuccessScore = score;
            IsDeleted = isDeleted;
        }
    }
}
