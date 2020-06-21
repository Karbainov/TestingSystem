using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    class AttemptQuestionAnswerFullInformationDTO
    {
        // Attempt info
        public int AttemptId { get; set; }
        public int Number { get; set; }
        public int UserResult { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }

        // Question info
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int TypeID { get; set; }
        public byte AnswersCount { get; set; }
        public byte Weight { get; set; }
        public List<int> AnswersId { get; set; }

        // Answer info
        public int AnswerId { get; set; }
        public string Answer { get; set; }
        public bool Correct { get; set; }

        // Extra id info
        public int TestId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
    }
}
