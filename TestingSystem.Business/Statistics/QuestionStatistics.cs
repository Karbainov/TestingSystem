using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingSystem.Business.Statistics.Models;

namespace TestingSystem.Business.Statistics
{
    public class QuestionStatistics:AbstractStatistics
    {
        public QuestionStatistics(int id)
        {
            InfoModelCreator creator = new InfoModelCreator();
            info = creator.CreateByQuestionId(id);
        }

        public Dictionary<int, int> CountNumberOfAnswersInAttemptByQuestionId(int questionId) 
        {
            Dictionary<int, int> answers = new Dictionary<int, int>();
            
            foreach (var i in info.IdInfo) 
            {
                if (i.QuestionId == questionId && !answers.ContainsKey(i.AnswerId)) 
                {
                    int answerId = i.AnswerId;                     
                    List<int> attemptId = new List<int>(info.Answers[answerId].Attempts);
                    int count = attemptId.Count;
                    answers.Add(answerId, count);
                }
            }
            return answers;
        }

        public Dictionary<int, double> GetPercentageOfPeopleChoosingAnswer(int questionId) 
        {
            Dictionary<int, int> answers = CountNumberOfAnswersInAttemptByQuestionId(questionId);
            Dictionary<int, double> answersPercent = new Dictionary<int, double> ();            
            List<int> attemptId = new List<int>();

            foreach (var j in info.IdInfo)
            {
                if (j.QuestionId == questionId && !attemptId.Contains(j.AttemptId))
                {
                    attemptId.Add(j.AttemptId);
                }                
            }
            foreach (var i in answers) 
            {             
                double result = ((double)i.Value / attemptId.Count * 100);
                answersPercent.Add(i.Key, result);
            }
            return answersPercent;
        }

        public double GetPercentageOfCorrectlyAnswered (int questionId)
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
