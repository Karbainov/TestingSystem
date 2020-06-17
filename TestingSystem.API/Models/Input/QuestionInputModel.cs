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
        public int TypeID { get; set; }
        public byte AnswersCount { get; set; }
        public byte Weight { get; set; }
    }
}
