using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class ConcreateAttemptOutputModel
    {
        int AttemptId { get; set; }
        int UserId { get; set; }
        int TestId { get; set; }
        public string TestName { get; set; }
        public TimeSpan? DurationTime { get; set; }

        List<QuestionWithListAnswersOutputModel> Questions { get; set; }
    }
}
