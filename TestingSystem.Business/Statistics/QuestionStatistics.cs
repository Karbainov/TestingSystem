using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingSystem.Business.Statistics.Models;

namespace TestingSystem.Business.Statistics
{
    public class QuestionStatistics:AStatistics
    {
        public QuestionStatistics(int id)
        {
            InfoModelCreator creator = new InfoModelCreator();
            info = creator.CreateByQuestionId(id);
        }

        public Dictionary<int, int> CountNumberOfAnswersInAttemptByQuestionId(int quId) 
        {
            Dictionary<int, int> question = new Dictionary<int, int>();
            
            foreach (var record in info.IdInfo) 
            {
                if (record.QuestionId == quId && !question.ContainsKey(record.AnswerId)) 
                {
                    int answerId = record.AnswerId;                     
                    List<int> attemptId = new List<int>(info.Answers[answerId].Attempts);
                    int count = attemptId.Count;
                    question.Add(answerId, count);
                }
            }
            return question;
        }

        public Dictionary<int, double> GetPercentOfAnswerToQuestion(int quId) 
        {
            Dictionary<int, int> answers = CountNumberOfAnswersInAttemptByQuestionId(quId);
            Dictionary<int, double> answersPercent = new Dictionary<int, double> ();            
            List<int> attemptId = new List<int>();

            foreach (var record in info.IdInfo)
            {
                if (record.QuestionId == quId && !attemptId.Contains(record.AttemptId))
                {
                    attemptId.Add(record.AttemptId);
                }                
            }
            foreach (var i in answers) 
            {             
                double result = ((double)i.Value / attemptId.Count * 100);
                answersPercent.Add(i.Key, result);
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
                        foreach(var b in info.Attempts.Keys)
                        {
                            if (a == b)
                            {
                                if (info.Questions[questionId].CorrectId.Count == info.Attempts[b].Answers.Count)
                                {
                                    foreach (var j in info.Questions[questionId].CorrectId)
                                    {
                                        foreach (var g in info.Attempts[b].Answers)
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
