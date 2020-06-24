﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingSystem.Business.Statistics.Models;

namespace TestingSystem.Business.Statistics
{
    public class TestStatistics
    {
        InfoForStatisticsModel info;
        
        public TestStatistics(InfoForStatisticsModel info)
        {
            this.info = info;
        }

        public List<int> GetAllResults(int id)
        {
            Dictionary<int, int> results = new Dictionary<int, int>();

            foreach (var record in info.IdInfo)
            {
                if(record.TestId == id)
                {
                    if(!results.ContainsKey(record.AttemptId))
                    {
                        int attemptId = record.AttemptId;
                        int result = info.Attempts[attemptId].UserResult;
                        results.Add(attemptId, result);
                    }
                }
            }

            return results.Values.ToList();
        }

        public double GetAverageResult(int id)
        {
            List<int> results = GetAllResults(id);
            if (results.Count == 0)
            {
                return Double.NaN;
            }

            double sum = 0;
            foreach(int i in results)
            {
                sum += i;
            }
            double avg = sum / results.Count();
            return avg;
        }

        public PassedFailedModel GetPassedFailedStats(int id)
        {
            List<int> results = GetAllResults(id);
            PassedFailedModel pf = new PassedFailedModel();
            int successScore = info.TestSuccessScores[id];
            foreach(int result in results)
            {
                if (result >= successScore)
                    pf.Passed++;
                else
                    pf.Failed++;
            }
            pf.SuccessRate = (double)pf.Passed / (pf.Passed + pf.Failed);
            return pf;
        }
    }
}
