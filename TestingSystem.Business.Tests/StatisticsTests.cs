using System;
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
        [TestCase(1, ExpectedResult = 20)]
        [TestCase(5, ExpectedResult = Double.NaN)]
        [TestCase(3, ExpectedResult = Double.NaN)]
        public double GetAverageResultsTest(int id)
        {      
            TestStatistics statistic = new TestStatistics(id);
            double actual = statistic.GetAverageResults(id);
            return actual;
        }    

        [TestCase(1)]
        [TestCase(7)]
        [TestCase(6)]        
        public void GetPassedFailedStatsTest(int id)
        {
            TestStatistics statistic = new TestStatistics(id);
            PassedFailedModel actual = statistic.GetPassedFailedStats(id);
            TestExpectedMock test = new TestExpectedMock();
            PassedFailedModel expected = test.GetPassedFailed(id);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4)]
        [TestCase(6)]
        [TestCase(13)]
        public void CountNumberOfAnswersInAttemptByQuestionIdTest(int questionId)
        {
            QuestionStatistics statistic = new QuestionStatistics(questionId);
            Dictionary<int, int> actual = statistic.CountNumberOfAnswersInAttemptByQuestionId(questionId);
            QuestionExpectedMock mock = new QuestionExpectedMock();
            Assert.AreEqual(mock.CountNumberOfAnswersInAttemptByQuestionId(questionId), actual);
        }

        [TestCase(4)]
        [TestCase(6)]
        [TestCase(13)]
        public void GetPercentageOfPeopleChoosingAnswerTest(int questionId)
        {
            QuestionStatistics statistic = new QuestionStatistics(questionId);
            Dictionary<int, double> actual = statistic.GetPercentageOfPeopleChoosingAnswer(questionId);
            QuestionExpectedMock mock = new QuestionExpectedMock();
            Assert.AreEqual(mock.GetPercentageOfPeopleChoosingAnswer(questionId), actual);
        }

        [TestCase(4)]
        [TestCase(6)]
        [TestCase(13)]
        public void GetPercentageOfCorrectlyAnsweredTest(int questionId)
        {
            QuestionStatistics statistic = new QuestionStatistics(questionId);
            double actual = statistic.GetPercentageOfCorrectlyAnswered(questionId);
            QuestionExpectedMock mock = new QuestionExpectedMock();
            Assert.AreEqual(mock.GetPercentageOfCorrectlyAnswered(questionId), actual);
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(5)]
        public void GetAverageResultsOfAllTestsByGroupIdTest(int groupId)
        {
            GroupStatistics statistic = new GroupStatistics(groupId);
            Dictionary<int, double> actual = statistic.GetAverageResultsOfAllTestsByGroupId(groupId);
            GroupExpectedMock mock = new GroupExpectedMock();
            Assert.AreEqual(mock.GetAverageResultsOfAllTestsByGroupId(groupId), actual);
        }
    }
}
