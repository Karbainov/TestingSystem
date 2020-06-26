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

        public PassedFailedModel GetPassedFailed(int id)
        {
            PassedFailedModel pfm = new PassedFailedModel();
            switch (id)
            {
                case 1:
                    pfm.Passed = 3;
                    pfm.Failed = 3;
                    pfm.SuccessRate = 50;
                    return pfm;

                case 6:
                    pfm.Passed = 0;
                    pfm.Failed = 0;
                    pfm.SuccessRate = 0;
                    return pfm;

                case 7:
                    pfm.Passed = 2;
                    pfm.Failed = 0;
                    pfm.SuccessRate = 100;
                    return pfm;

            }

            pfm.Passed = -1;
            pfm.Failed = -1;
            pfm.SuccessRate = -1;
            return pfm;

        }
    }
}
