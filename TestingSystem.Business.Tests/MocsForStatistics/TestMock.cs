using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Business.Statistics.Models;

namespace TestingSystem.Business.Tests.MocsForStatistics
{
    class TestMock
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
                    pfm.Passed = 4;
                    pfm.Failed = 5;
                    pfm.SuccessRate = 0.4;
                    return pfm;
                case 5:
                    pfm.Passed = 0;
                    pfm.Failed = 0;
                    pfm.SuccessRate = 0;
                    return pfm;
                case 3:
                    pfm.Passed = 0;
                    pfm.Failed = 0;
                    pfm.SuccessRate = 0;
                    return pfm;
            }
            pfm.Passed = -1;
            pfm.Failed = -1;
            pfm.SuccessRate = -1;
            return pfm;
        }


    }
}
