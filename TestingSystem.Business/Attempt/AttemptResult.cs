using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.StoredProcedure.CRUD;

namespace TestingSystem.Business.Attempt
{
    public class AttemptResult
    {
        public int GetAttemptResult(int attemptID) { return 0; }

        public void RecountAttemptsResult(int id, byte count)
        {
            QuestionCRUD question = new QuestionCRUD();
            QuestionDTO questions = question.GetById(id);
            questions.Weight = count;
            question.Update(questions);
            AttemptQuestionAnswerCRUD attemptQuestionAnswerCRUD = new AttemptQuestionAnswerCRUD();
            List<AttemptQuestionAnswerDTO> attemptQuestionAnswers = attemptQuestionAnswerCRUD.GetAll();
            AttemptManager manager = new AttemptManager();
            foreach(AttemptQuestionAnswerDTO aqa in attemptQuestionAnswers)
            {
                if(aqa.QuestionID==id)
                {
                    manager.UpdateResult(aqa.AttemptID);
                }
            }
        }
    }
}
