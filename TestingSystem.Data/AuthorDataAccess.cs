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
        
        public int AddFeedback(FeedbackDTO feedback)
        {
            FeedbackCRUD fb = new FeedbackCRUD();
            return fb.FeedbackAdd(feedback);
        }

        public List<FeedbackDTO> GetAllFeedback()
        {
            FeedbackCRUD fb = new FeedbackCRUD();
            return fb.FeedbackGetAll();
        }

        public void UpdateFeedback(FeedbackDTO feedback)
        {
            FeedbackCRUD fb = new FeedbackCRUD();
            fb.FeedbackUpdate(feedback);
        }

        public void DeleteFeedback(FeedbackDTO feedback)
        {
            FeedbackCRUD fb = new FeedbackCRUD();
            fb.FeedbackDelete(feedback);
        }


        // Question CRUD methods

        public int AddQuestion(QuestionDTO question)
        {
            QuestionCRUD q = new QuestionCRUD();
            return q.Add(question);
        }

        public List<QuestionDTO> GetAllQuestions()
        {
            QuestionCRUD q = new QuestionCRUD();
            return q.GetAll();
        }

        public List<QuestionDTO> GetQuestionsByTestID(int testId)
        {
            QuestionCRUD q = new QuestionCRUD();
            return q.GetByTestID(testId);
        }

        public List<QuestionDTO> GetQuestionsByTypeID(int typeId)
        {
            QuestionCRUD q = new QuestionCRUD();
            return q.GetByTypeID(typeId);
        }

        public QuestionDTO GetQuestionsByTagID(int id)
        {
            QuestionCRUD q = new QuestionCRUD();
            return q.GetById(id);
        }

        public void UpdateQuestion(QuestionDTO question)
        {
            QuestionCRUD q = new QuestionCRUD();
            q.Update(question);
        }

        public void DeleteFeedback(QuestionDTO question)
        {
            QuestionCRUD q = new QuestionCRUD();
            q.Delete(question.ID);
        }

        // Type CRUD methods

        public int AddType(TypeDTO type)
        {
            TypeCRUD typeCRUD = new TypeCRUD();
            return typeCRUD.Add(type);
        }

        public List<TypeDTO> GetAllTypes()
        {
            TypeCRUD typeCRUD = new TypeCRUD();
            return typeCRUD.GetAll();
        }

        public TypeDTO GetTypesByTagID(int id)
        {
            TypeCRUD typeCRUD = new TypeCRUD();
            return typeCRUD.GetById(id);
        }

        public void UpdateType(TypeDTO type)
        {
            TypeCRUD typeCRUD = new TypeCRUD();
            typeCRUD.Update(type);
        }

        public void DeleteType(TypeDTO type)
        {
            TypeCRUD typeCRUD = new TypeCRUD();
            typeCRUD.Delete(type.ID);
        }


    }
}
