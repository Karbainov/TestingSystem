using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class TestQuestionTagDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<TimeSpan> DurationTime { get; set; }
        public Nullable<byte> SuccessScore { get; set; }
        public Nullable<int> QuestionNumber { get; set; }


        public List<QuestionForOneToManyDTO> Questions { get; set; }
        public List<TagWithTestIDDTO> Tags { get; set; }
    }
}
