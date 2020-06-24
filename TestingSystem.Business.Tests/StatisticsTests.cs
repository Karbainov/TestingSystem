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
        InfoModelCreator creator = new InfoModelCreator();

        [TestCase(1, ExpectedResult = 27.4)]
        [TestCase(5, ExpectedResult = 0)]
        [TestCase(3, ExpectedResult = 0)]

        public double GetAverageResultTest(int id)
        {      
            TestStatistics statistic = new TestStatistics(id);
            double actual = statistic.GetAverageResult(id);
            return actual;
        }
    

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(3)]
        
        public void GetPassedFailedStatsTest(int id)
        {
            TestStatistics statistic = new TestStatistics(id);
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
            QuestionStatistics statistic = new QuestionStatistics(questionId);
            Dictionary<int, int> actual = statistic.CountNumberOfAnswersInAttemptByQuestionId(questionId);
            QuestionMock mock = new QuestionMock();
            Assert.AreEqual(mock.CountNumberOfAnswerMock(questionId), actual);
        }

        [TestCase(4)]
        [TestCase(6)]
        [TestCase(13)]

        public void GetPercentOfAnswerToQuestionTest(int questionId)
        {
            QuestionStatistics statistic = new QuestionStatistics(questionId);
            Dictionary<int, double> actual = statistic.GetPercentOfAnswerToQuestion(questionId);
            QuestionMock mock = new QuestionMock();
            Assert.AreEqual(mock.GetPercentOfAnswerMock(questionId), actual);
        }

        [TestCase(4)]
        [TestCase(6)]
        [TestCase(13)]

        public void FindPercentCorrectAnswersByQuestionTest(int questionId)
        {
            QuestionStatistics statistic = new QuestionStatistics(questionId);
            double actual = statistic.FindPercentCorrectAnswersByQuestion(questionId);
            QuestionMock mock = new QuestionMock();
            Assert.AreEqual(mock.FindPercentCorrectMock(questionId), actual);
        }




    }
}
