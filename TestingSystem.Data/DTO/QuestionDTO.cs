using System;
namespace TestingSystem.Data.DTO
{
    public class QuestionDTO
    {
        public int ID { get; set; }
        public int TestID { get; set; }
        public string Value { get; set; }
        public int? TypeID { get; set; }
        public byte? AnswersCount { get; set; }
        public byte? Weight { get; set; }

        public QuestionDTO()
        {

        }

        public QuestionDTO(int ID, int TestID, string Value, int TypeID, byte AnswersCount, byte Weight)
        {
            this.ID = ID;
            this.TestID = TestID;
            this.Value = Value;
            this.TypeID = TypeID;
            this.AnswersCount = AnswersCount;
            this.Weight = Weight;
        }
    }
}
