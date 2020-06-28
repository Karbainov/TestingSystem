using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Tests.MocsForStatistics
{
    public class GroupExpectedMock
    {
        public Dictionary<int, double> GetAverageResultsOfAllTestsByGroupId(int groupId) 
        {
            Dictionary<int, double> mock = new Dictionary<int, double>();
            switch (groupId)
            {
                case 1:
                    mock.Add(1, 20);
                    return mock;
                case 6:
                    mock.Add(15, 69);
                    mock.Add(16, 74.5);
                    mock.Add(17, 82);
                    return mock;
                case 5:
                    mock.Add(2, 85);
                    mock.Add(19, 71);
                    return mock;
            }
            return mock;
        }
    }
}
