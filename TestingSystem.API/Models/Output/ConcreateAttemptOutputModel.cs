using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class ConcreateAttemptOutputModel
    {
        public int AttemptId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public TimeSpan? DurationTime { get; set; }

        public List<QuestionWithListAnswersOutputModel> Questions { get; set; }
    }
}
