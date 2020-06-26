using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Statistics.Models
{
    public class PassedFailedModel
    {
        public int Passed { get; set; }
        public int Failed { get; set; }
        public int SuccessRate { get; set; }

        public PassedFailedModel()
        {
            
        }
    }
}
