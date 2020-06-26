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

        public Dictionary<int, double> GetAverageGroupResultForAllTests(int groupId)   
        {
            Dictionary<int, double> result = new Dictionary<int, double>();
            foreach (var record in info.IdInfo)
            {
                if (record.GroupId == groupId)
                {
                    if (!result.ContainsKey(record.TestId))
                    {
                        int testId = record.TestId;
                        double averageTest = GetAverageResult(testId);
                        result.Add(testId, averageTest);
                    }
                }
            }
            return result;
        }
    }
}
