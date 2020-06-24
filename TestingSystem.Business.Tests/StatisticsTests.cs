using NUnit.Framework;
using System.Collections.Generic;
using TestingSystem.Business.Statistics;
using TestingSystem.Business.Statistics.Models;
using TestingSystem.Business.Statistics.Models.InfoModels;
using TestingSystem.Business.Tests.MocsForStatistics;
namespace TestingSystem.Business.Tests
{
    public class StatisticsTests
    {
        InfoForStatisticsModel info = new InfoForStatisticsModel();
        InfoModelCreator creator = new InfoModelCreator();

        [TestCase(1, ExpectedResult = 27.4)]
        [TestCase(5, ExpectedResult = 0)]
        [TestCase(3, ExpectedResult = 0)]

        public double GetAverageResultTest(int id)
        {
            info = creator.CreateByTestId(id);            
            TestStatistics statistic = new TestStatistics(info);
            double actual = statistic.GetAverageResult(id);
            return actual;
        }
    

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(3)]
        
        public void GetPassedFailedStatsTest(int id)
        {
            info = creator.CreateByTestId(id);
            TestStatistics statistic = new TestStatistics(info);
            PassedFailedModel actual = statistic.GetPassedFailedStats(id);
            TestMock test = new TestMock();
            PassedFailedModel expected = test.GetPassedFailed(id);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4)]
        [TestCase(6)]
        [TestCase(13)]

        public void CountNumberOfAnswersForAttemptByQuestionIdTest(int questionId)
        {
            info = creator.CreateByQuestionId(questionId);
            QuestionStatistics statistic = new QuestionStatistics(info);
            Dictionary<int, int> actual = statistic.CountNumberOfAnswersInAttemptByQuestionId(questionId);
            QuestionMock mock = new QuestionMock();
            Assert.AreEqual(mock.CountNumberOfAnswerMock(questionId), actual);
        }

        [TestCase(4)]
        [TestCase(6)]
        [TestCase(13)]

        public void GetPercentOfAnswerToQuestionTest(int questionId)
        {
            info = creator.CreateByQuestionId(questionId);
            QuestionStatistics statistic = new QuestionStatistics(info);
            Dictionary<int, double> actual = statistic.GetPercentOfAnswerToQuestion(questionId);
            QuestionMock mock = new QuestionMock();
            Assert.AreEqual(mock.GetPercentOfAnswerMock(questionId), actual);
        }

        [TestCase(4)]
        [TestCase(6)]
        [TestCase(13)]

        public void FindPercentCorrectAnswersByQuestionTest(int questionId)
        {
            info = creator.CreateByQuestionId(questionId);
            QuestionStatistics statistic = new QuestionStatistics(info);
            double actual = statistic.FindPercentCorrectAnswersByQuestion(questionId);
            QuestionMock mock = new QuestionMock();
            Assert.AreEqual(mock.FindPercentCorrectMock(questionId), actual);
        }




    }
}
