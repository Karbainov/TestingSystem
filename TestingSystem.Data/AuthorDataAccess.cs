using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.StoredProcedure;

namespace TestingSystem.Data
{
    public class AuthorDataAccess
    {
        public void QuestionDeleteFromTest(int questionId)
        {
            QuestionDeleteFromTests question = new QuestionDeleteFromTests();
            question.QuestionDelete(questionId);
        }

        
    }
}
