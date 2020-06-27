using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Business.Statistics.Models.InfoModels;
using TestingSystem.Business.Statistics;
using TestingSystem.Business.Statistics.Models;

namespace TestingSystem.Business.Statistics
{
    public class GroupStatistics:TestStatistics
    {
        public GroupStatistics(int id)
        {
            InfoModelCreator creator = new InfoModelCreator();
            info = creator.CreateByGroupId(id);
        }

        public Dictionary<int, double> GetAverageResultsOfAllTestsByGroupId(int groupId)   
        {
            Dictionary<int, double> results = new Dictionary<int, double>();
            foreach (var i in info.IdInfo)
            {
                if (i.GroupId == groupId)
                {
                    if (!results.ContainsKey(i.TestId))
                    {
                        int testId = i.TestId;
                        double averageResultOfTest = GetAverageResults(testId);
                        results.Add(testId, averageResultOfTest);
                    }
                }
            }
            return results;
        }
    }
}
