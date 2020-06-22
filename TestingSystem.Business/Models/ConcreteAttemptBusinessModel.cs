using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.Business.Models
{
    public class ConcreteAttemptBusinessModel
    {
        public int AttemptId { get; set; }
        public TimeSpan? DurationTime { get; set; }
        public List<QuestionWithAnswersBusinessModel> Questions { get; set; }
        
        public ConcreteAttemptBusinessModel(int attemptId, TimeSpan? durationTime, List<QuestionWithAnswersBusinessModel> questions)
        {
            AttemptId = attemptId;
            DurationTime = durationTime;
            Questions = questions;
        }
    }
}
