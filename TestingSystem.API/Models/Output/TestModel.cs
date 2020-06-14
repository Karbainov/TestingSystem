using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan DurationTime { get; set; }
        public int SuccessScore { get; set; }

        public List<QuestionModel> Questions { get; set; }
        public List<string> Tags { get; set; }
    }
}
