using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Statistics.Models
{
    public struct PassedFailedModel
    {
        public int Passed { get; set; }
        public int Failed { get; set; }
        public double SuccessRate { get; set; }

    }
}
