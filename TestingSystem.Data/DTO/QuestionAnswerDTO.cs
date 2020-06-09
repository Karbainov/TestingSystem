using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class QuestionAnswerDTO
    {
        public int ID { get; set; }
        public int TestID { get; set; }
        public string QValue { get; set; }
        public int TypeID { get; set; }
        public byte AnswersCount { get; set; }
        public byte Weight { get; set; }
        public int QuestionID { get; set; }
        public string AValue { get; set; }
        public bool Correct { get; set; }

        // все поля question  и список answer


        public QuestionAnswerDTO(int ID, int TestID, string QValue, int TypeID, byte AnswersCount, byte Weight, int _questionID, string _AValue, bool _correct)
        { 
            this.ID = ID;
            this.TestID = TestID;
            this.QValue = QValue;
            this.TypeID = TypeID;
            this.AnswersCount = AnswersCount;
            this.Weight = Weight;
            QuestionID = _questionID;
            AValue = _AValue;
            Correct = _correct;
        }

        public QuestionAnswerDTO(string QValue, string _AValue)
        {
            this.QValue = QValue;
            AValue = _AValue;
        }

        public QuestionAnswerDTO()
        { }
    }
}
