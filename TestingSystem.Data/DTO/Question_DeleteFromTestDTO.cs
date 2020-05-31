using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class Question_DeleteFromTestDTO
    {
        public int questionId { get; set; }
        public int testId { get; set; }

        public Question_DeleteFromTestDTO() { }

        public Question_DeleteFromTestDTO(int questionId, int testId)
        {
            this.questionId = questionId;
            this.testId = testId;

        }

    }
}
