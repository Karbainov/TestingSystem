using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingSystem.Business.Statistics.Models;

namespace TestingSystem.Business.Statistics
{
    public class TestStatistics : AbstractStatistics
    {
        public TestStatistics() { }
        public TestStatistics(int id)
        {
            InfoModelCreator creator = new InfoModelCreator();
            info = creator.CreateByTestId(id);
        }

        public List<int> GetAllResults(int id)
        {
            Dictionary<int, int> results = new Dictionary<int, int>();

            foreach (var record in info.IdInfo)
            {
                if (record.TestId == id)
                {
                    if (!results.ContainsKey(record.AttemptId))
                    {
                        int attemptId = record.AttemptId;
                        int result = info.Attempts[attemptId].UserResult;
                        results.Add(attemptId, result);
                    }
                    return new List<int>();
                }
            }            
            return results.Values.ToList();
        }

        public double GetAverageResults(int id)
        {
            List<int> results = GetAllResults(id);
            double avg = 0;

            if (results.Count == 0)
            {
                return avg;
            }

            double sum = 0;
            foreach (int i in results)
            {
                sum += i;
            }
            avg = sum / results.Count();
            return avg;
        }

        public PassedFailedModel GetPassedFailedStats(int id)
        {
            List<int> results = GetAllResults(id);
            PassedFailedModel pf = new PassedFailedModel();
            
            if (!info.TestSuccessScores.ContainsKey(id))
                return pf;

            int successScore = info.TestSuccessScores[id];
            foreach (int result in results)
            {
                if (result >= successScore)
                    pf.Passed++;
                else
                    pf.Failed++;
            }
            pf.SuccessRate =(double) (pf.Passed) / (pf.Passed + pf.Failed) * 100;
            return pf;
        }
    }
}
