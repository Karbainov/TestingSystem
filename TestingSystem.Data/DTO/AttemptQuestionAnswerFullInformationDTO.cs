using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class AttemptQuestionAnswerFullInformationDTO
    {
        // Attempt info
        public int AttemptID { get; set; }
        public int AttemptNumber { get; set; }
        public int UserResult { get; set; }
        public DateTime AttemptDateTime { get; set; }
        public TimeSpan AttemptDurationTime { get; set; }

        // Question info
        public int QuestionID { get; set; }
        public string QuestionValue { get; set; }
        public int TypeID { get; set; }
        public byte AnswersCount { get; set; }
        public byte Weight { get; set; }
        public List<int> AnswersID { get; set; }

        // Answer info
        public int AnswerID { get; set; }
        public string Value { get; set; }
        public bool Correct { get; set; }

        // Extra id info
        public int TestID { get; set; }
        public int SuccessScore { get; set; }
        public int GroupID { get; set; }
        public int UserID { get; set; }
    }
}
