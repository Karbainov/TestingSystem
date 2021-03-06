﻿using System;
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
        public Dictionary<int, int> TestSuccessScores { get; set; }        

        public InfoForStatisticsModel()
        {
            IdInfo = new List<AttemptQuestionAnswerAllIdsModel>();
            Questions = new Dictionary<int, QuestionInfoModel>();
            Answers = new Dictionary<int, AnswerInfoModel>();
            Attempts = new Dictionary<int, AttemptInfoModel>();
            TestSuccessScores = new Dictionary<int, int>();
        }
    }
}
