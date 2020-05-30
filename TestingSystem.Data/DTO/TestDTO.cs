using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public TimeSpan duration { get; set; }
        public int score { get; set; }

        public TestDTO()
        {
        }

        public TestDTO(int Id)
        {
            this.Id = Id;
        }

        public TestDTO(int Id, string name, TimeSpan duration, int score)
        {
            this.Id = Id;
            this.name = name;
            this.duration = duration;
            this.score = score;
        }
    }
}
