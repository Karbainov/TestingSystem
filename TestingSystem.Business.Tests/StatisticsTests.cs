using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Business.Statistics;
using TestingSystem.Business.Statistics.Models;
using TestingSystem.Business.Tests.ModelsForTests;

namespace TestingSystem.Business.Tests
{
    public class StatisticsTests
    {
        InfoForStatisticsModel info = new InfoForStatisticsModel();
    
        [TestCase(1, ExpectedResult = 2.4)]
        [TestCase(5, ExpectedResult = 0)]
        [TestCase(3, ExpectedResult = 0)]

        public double AverageResultTest(int id)
        {
            TestStatistics statistic = new TestStatistics(info);
            double actual = statistic.AverageResult(id);
            return actual;
        }
    

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(3)]
        
        public void PassedFailedStatsTests(int id)
        {
            TestStatistics statistic = new TestStatistics(info);
            PassedFailedModel actual = statistic.PassedFailedStats(id);
            PassedFailTest test = new PassedFailTest();
            PassedFailedModel expected = test.GetPassedFailed(id);
            Assert.AreEqual(expected, actual);
        }




    }
}
