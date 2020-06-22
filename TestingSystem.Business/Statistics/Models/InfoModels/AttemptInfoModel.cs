using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Business.Statistics.Models
{
    public class AttemptInfoModel
    {
        public int Number { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public int UserResult { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration{ get; set; }
    }
}
