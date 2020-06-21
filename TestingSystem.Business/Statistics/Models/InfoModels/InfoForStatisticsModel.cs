using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Statistics.Models
{
    public class InfoForStatisticsModel
    {
        public List<AttemptQuestionAnswerAllIdsModel> IdInfo { get; set; }
        public Dictionary<int, QuestionInfoModel> Questions { get; set; }
        public Dictionary<int, AnswerInfoModel> Answers { get; set; }
        public Dictionary<int, AttemptInfoModel> Attempts { get; set; }
        public Dictionary<int, AnswerAttemptsInfoModel> AnswerAttemptsInfo { get; set; }
        public Dictionary<int, int> TestSuccessScores { get; set; }        
        public Dictionary<int, AttemptAnswersModel> AttemptAnswers { get; set; }
    }
}
