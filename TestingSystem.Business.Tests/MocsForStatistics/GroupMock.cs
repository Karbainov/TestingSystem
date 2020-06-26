using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Tests.MocsForStatistics
{
    public class GroupMock
    {
        public Dictionary<int, double> GetAverageGroupResultForAllTests(int groupId) 
        {
            Dictionary<int, double> mock = new Dictionary<int, double>();
            switch (groupId)
            {
                case 1:
                    mock.Add(1, 20);
                    return mock;
                //case 6:
                //    mock.Add(7, 1);
                //    mock.Add(8, 3);
                //    mock.Add(9, 3);
                //    mock.Add(26, 3);
                //    return mock;
                //case 13:
                //    mock.Add(22, 1);
                //    return mock;
            }
            return mock;
        }
    }
}
