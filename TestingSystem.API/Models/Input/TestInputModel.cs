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
        public string DurationTime { get; set; }
        public byte? SuccessScore { get; set; }
        public int? QuestionNumber { get; set; }
    }
}
