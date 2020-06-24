using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Business.Statistics.Models.InfoModels;
using TestingSystem.Business.Statistics;
using TestingSystem.Business.Statistics.Models;

namespace TestingSystem.Business.Statistics
{
    public class GroupStatistics
    {
        InfoForStatisticsModel info;

        public Dictionary<int, double> GetAverageGroupResultForAllTests(int groupId)   
        {            
            GroupInfoModel group = new GroupInfoModel();
            TestStatistics ts = new TestStatistics(info);
            Dictionary<int, double> result = new Dictionary<int, double>();
            foreach (int t in group.TestsId) 
            {
                double averageTest = ts.GetAverageResult(t);
                result.Add(t, averageTest);
            }
            return result;
        }
    }
}
