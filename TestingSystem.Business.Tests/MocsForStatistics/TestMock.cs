using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Business.Statistics.Models;

namespace TestingSystem.Business.Tests.MocsForStatistics
{
    public class TestMock
    {
        public TestMock()
        {
        }

        public List<double> GetPassedFailed(int id)
        {
            PassedFailedModel pfm = new PassedFailedModel();
            switch (id)
            {
                case 1:
                    //pfm.Passed = 3;
                    //pfm.Failed = 3;
                    //pfm.SuccessRate = 50;
                    //return pfm;
                    return new List<double> { 3, 3, 50 };
                case 6:
                    return new List<double> { Double.NaN, Double.NaN, Double.NaN };
                case 7:                    
                    return new List<double> { 2, 0, 100 };
            }
            //pfm.Passed = -1;
            //pfm.Failed = -1;
            //pfm.SuccessRate = -1;
            //return pfm;
            return new List<double> { 0, 0, 0 };
        }


    }
}
