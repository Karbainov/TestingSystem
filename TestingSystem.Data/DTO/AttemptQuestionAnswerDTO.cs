using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class AttemptQuestionAnswerDTO
    {
        public int ID { get; set; }
        public int AttemptID { get; set; }
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }

        public AttemptQuestionAnswerDTO()
        {

        }

        public AttemptQuestionAnswerDTO(int ID, int AttemptID, int QuestionID, int AnswerID)
        {
            this.ID = ID;
            this.AttemptID = AttemptID;
            this.QuestionID = QuestionID;
            this.AnswerID = AnswerID;
        }
    }
}