using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Input
{
    public class ConcreteAttemptInputModel
    {
        public int AttemptId { get; set; }
        public TimeSpan? DurationTime { get; set; }

        public List<QuestionWithAnswersInputModel> Questions { get; set; }
    }
}
