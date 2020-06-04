using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.StoredProcedure.CRUD;

namespace TestingSystem.Data
{
    public class AuthorDataAccess
    {
        public void QuestionDeleteFromTest(int questionId)
        {
            QuestionManager question = new QuestionManager();
            question.DeleteQuestionFromTest(questionId);
        }

        public List<Question_AnswerDTO> AnswerGetCorrectByTestID(TestDTO test)
        {
            TestManager managerAnswer = new TestManager();
            List<Question_AnswerDTO> ACT = new List<Question_AnswerDTO>(managerAnswer.Answer_GetCorrectByTestID(test));
            return ACT;
        }

        public int TestTagCreate(TestTagDTO testtag)
        {
            TestTagCRUD tt= new TestTagCRUD();
            int i = tt.Add(testtag);
            return i;
        }        
    }
}
