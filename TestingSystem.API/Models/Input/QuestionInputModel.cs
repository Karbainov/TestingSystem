using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Input
{
    public class QuestionInputModel
    {
        public int ID { get; set; }
        public int TestID { get; set; }
        public string Value { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<byte> AnswersCount { get; set; }
        public Nullable<byte> Weight { get; set; }
    }
}
