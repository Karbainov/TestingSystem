using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.DTO;

namespace TestingSystem.Business.Statistics.Models
{
    public class InfoModelCreator
    {
        public InfoForStatisticsModel CreateByTestId(int id)
        {
            var manager = new AttemptQuestionAnswerFullInfoManager();
            var data = manager.GetByTestId(id);
            return Create(data);
        }
        public InfoForStatisticsModel CreateByGroupId(int id)
        {
            var manager = new AttemptQuestionAnswerFullInfoManager();
            var data = manager.GetByGroupId(id);
            return Create(data);
        }
        public InfoForStatisticsModel CreateByQuestionId(int id)
        {
            var manager = new AttemptQuestionAnswerFullInfoManager();
            var data = manager.GetByQuestionId(id);
            return Create(data);
        }
        public InfoForStatisticsModel CreateByUserId(int id)
        {
            var manager = new AttemptQuestionAnswerFullInfoManager();
            var data = manager.GetByUserId(id);
            return Create(data);
        }

        private InfoForStatisticsModel Create(List<AttemptQuestionAnswerFullInformationDTO> data)
        {
            InfoForStatisticsModel info = new InfoForStatisticsModel();

            foreach (var item in data)
            {
                AttemptQuestionAnswerAllIdsModel idModel = new AttemptQuestionAnswerAllIdsModel
                {
                    AttemptId = item.AttemptID,
                    QuestionId = item.QuestionID,
                    AnswerId = item.AnswerID,
                    TestId = item.TestID,
                    UserId = item.UserID,
                    GroupId = item.GroupID
                };
                info.IdInfo.Add(idModel);

                if (!info.Attempts.ContainsKey(item.AttemptID))
                {
                    AttemptInfoModel attemptInfo = new AttemptInfoModel()
                    {
                        Number = item.AttemptNumber,
                        TestId = item.TestID,
                        UserId = item.UserID,
                        UserResult = item.UserResult,
                        Date = item.AttemptDateTime,
                        Duration = item.AttemptDurationTime
                    };
                    info.Attempts.Add(item.AttemptID, attemptInfo);
                }

                if (!info.Questions.ContainsKey(item.QuestionID))
                {
                    QuestionInfoModel questionInfo = new QuestionInfoModel()
                    {
                        TestId = item.TestID,
                        Value = item.QuestionValue,
                        TypeId = item.TypeID,
                        AnswersCount = item.AnswersCount,
                        Weight = item.Weight
                    };
                    info.Questions.Add(item.QuestionID, questionInfo);
                }

                if (!info.Answers.ContainsKey(item.AnswerID))
                {
                    AnswerInfoModel answerInfo = new AnswerInfoModel()
                    {
                        QuestionID = item.QuestionID,
                        Value = item.Value,
                        Correct = item.Correct
                    };
                    info.Answers.Add(item.AnswerID, answerInfo);
                }

                if (!info.TestSuccessScores.ContainsKey(item.TestID))
                {
                    info.TestSuccessScores.Add(item.TestID, item.SuccessScore);
                }
            }

            CreateAnswerAttemptsLists(info);
            CreateAttemptAnswersLists(info);
            CreateQuestionAnswersLists(info);
            return info;
        }

        private void CreateAnswerAttemptsLists(InfoForStatisticsModel info)
        {
            foreach(var answer in info.Answers)
            {
                answer.Value.Attempts = new List<int>();
                foreach (var record in info.IdInfo)
                {
                    if (answer.Key == record.AnswerId)
                    {
                        answer.Value.Attempts.Add(record.AttemptId);
                    }
                }
            }
        }

        private void CreateAttemptAnswersLists(InfoForStatisticsModel info)
        {
            foreach (var attempt in info.Attempts)
            {
                attempt.Value.Answers = new List<int>();
                foreach (var record in info.IdInfo)
                {
                    if (attempt.Key == record.AnswerId)
                    {
                        attempt.Value.Answers.Add(record.AttemptId);
                    }
                }
            }
        }

        private void CreateQuestionAnswersLists(InfoForStatisticsModel info)
        {
            foreach (int testId in info.TestSuccessScores.Keys)
            {
                QuestionManager qm = new QuestionManager();
                List<QuestionWithListAnswersDTO> testQuestions = qm.GetQuestionsAndAnswers(testId);
                foreach(var question in testQuestions)
                {
                    if (info.Questions.ContainsKey(question.Id))
                    {
                        info.Questions[question.Id].AnswersId = new List<int>();
                        foreach(var answer in question.Answers)
                        {
                            info.Questions[question.Id].AnswersId.Add(answer.AnswerId);
                        }
                    }
                }
            }
        }
    }
}
