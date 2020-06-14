using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class SearchTestByTagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan DurationTime { get; set; }
        public int SuccessScore { get; set; }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }

        public SearchTestByTagDTO() { }

        public SearchTestByTagDTO(int id, string name, TimeSpan durationTime, int successScore, string tag1, string tag2, string tag3)
        {
            this.Id = id;
            this.Name = name;
            this.DurationTime = durationTime;
            this.SuccessScore = successScore;
            this.Tag1 = tag1;
            this.Tag2 = tag2;
            this.Tag3 = tag3;
        }
    }
}
