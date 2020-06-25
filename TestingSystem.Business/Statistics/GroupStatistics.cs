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
            GroupInfoModel group = new GroupInfoModel();
            Dictionary<int, double> result = new Dictionary<int, double>();
            foreach (int t in group.TestsId) 
            {
                double averageTest = GetAverageResult(t);
                result.Add(t, averageTest);
            }
            return result;
        }
    }
}
