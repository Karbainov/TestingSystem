using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO.DTOsForStatistics;

namespace TestingSystem.Business.Statistics
{
    class QuestionStatistics
    {
        InfoForStatisticsDTO info;

        public QuestionStatistics(InfoForStatisticsDTO info)
        {
            this.info = info;
        }

        public Dictionary<int, int> AllQuestionResult(int quId) 
        {
            Dictionary<int, int> question = new Dictionary<int, int>();
            
            foreach (var record in info.IdInfo) 
            {
                if (record.QuestionId == quId) 
                {
                    int answerId = record.AnswerId;
                    List<int> attemptId = new List<int>(info.AnswerAttemptsInfo[answerId].AttemptId);
                    int count = attemptId.Count;
                    question.Add(answerId, count);
                }
            }
            return question;
        }

        public Dictionary<int, double> QuResult(int quId) 
        {
            Dictionary<int, int> answers = AllQuestionResult(quId);
            Dictionary<int, double> answersPercent = new Dictionary<int, double> ();
            int aCount = 0;

            foreach (var record in info.IdInfo)
            {
                if (record.QuestionId == quId)
                {
                    aCount++;
                }
            }
            foreach (var i in answers) 
            {
                int a = i.Key;
                int sum = i.Value;
                double result = sum / aCount * 100;
                answersPercent.Add(a, result);
            }
            return answersPercent;
        }
    }
}
