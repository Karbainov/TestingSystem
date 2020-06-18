using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Input
{
    public class TestInputModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<TimeSpan> DurationTime { get; set; }
        public Nullable<byte> SuccessScore { get; set; }
        public Nullable<int> QuestionNumber { get; set; }
    }
}
