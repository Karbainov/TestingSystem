using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO.DTOsForStatistics
{
    public class InfoForStatisticsDTO
    {
        public List<AttemptQuestionAnswerAllIdsDTO> IdInfo { get; set; }
        public Dictionary<int, QuestionInfoDTO> Questions { get; set; }
        public Dictionary<int, AnswerInfoDTO> Answers { get; set; }
        public Dictionary<int, AttemptInfoDTO> Attempts { get; set; }
        public Dictionary<int, AnswerAttemptsInfoDTO> AnswerAttemptsInfo { get; set; }
        public Dictionary<int, int> TestSuccessScores { get; set; }        
        public Dictionary<int, AttemptAnswersDTO> AttemptAnswers { get; set; }
    }
}
