using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingSystem.Business.Statistics.Models;

namespace TestingSystem.Business.Statistics
{
    class QuestionStatistics
    {
        InfoForStatisticsModel info;    

        public QuestionStatistics(InfoForStatisticsModel info)
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

        public double FindPercentCorrectAnswersByQuestion (int questionId)
        {
            int correct = 0;
            int sumCorrect = 0;             
            List<int> attemptId = new List<int>();
            foreach (var i in info.IdInfo)
            {
                if (questionId == i.QuestionId)
                {
                    attemptId.Add(i.AttemptId);
                    foreach (var a in attemptId)
                    {    
                        foreach(var b in info.AttemptAnswers.Keys)
                        {
                            if (a == b)
                            {
                                if (info.Questions[questionId].CorrectId.Count == info.AttemptAnswers[b].StudentAnswersId.Count)
                                {
                                    foreach (var j in info.Questions[questionId].CorrectId)
                                    {
                                        foreach (var g in info.AttemptAnswers[b].StudentAnswersId)
                                        {
                                            if (j == g)
                                            {
                                                correct++;
                                            }
                                        }
                                    }
                                    if (info.Questions[questionId].CorrectId.Count == correct)
                                    {
                                        sumCorrect++;
                                    }
                                }                               
                            }
                        }                       
                    }
                }
            }
            return sumCorrect / attemptId.Count * 100;            
        }
    }
}
