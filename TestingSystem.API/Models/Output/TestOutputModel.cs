using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class TestOutputModel
    {
       
        public int ID { get; set; }
        public string Name { get; set; }        
        public Nullable<TimeSpan> DurationTime { get; set; }
        public Nullable<byte> SuccessScore { get; set; }
        public Nullable<int> QuestionNumber { get; set; }


        public List<QuestionOutputModel> Questions { get; set; }
        public List<TagOutputModel> Tags { get; set; }
        
    }
}
