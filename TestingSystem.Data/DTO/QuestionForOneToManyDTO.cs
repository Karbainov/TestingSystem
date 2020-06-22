using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class QuestionForOneToManyDTO
    {
        public int QID { get; set; }
        public int TestID { get; set; }
        public string Value { get; set; }
        public int Type { get; set; }
        public int AnswersCount { get; set; }
        public int Weight { get; set; }

        public QuestionForOneToManyDTO()
        {

        }

        public QuestionForOneToManyDTO(int QID, int TestID, string Value, int TypeID, int AnswersCount, int Weight)
        {
            this.QID = QID;
            this.TestID = TestID;
            this.Value = Value;
            this.Type = TypeID;
            this.AnswersCount = AnswersCount;
            this.Weight = Weight;
        }
    }
}
