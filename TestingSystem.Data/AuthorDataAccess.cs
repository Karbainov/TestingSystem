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
        //AnswerCRUD 

        public int AddAnswer(AnswerDTO answer)
        {
            AnswerCRUD answr = new AnswerCRUD();
            return answr.AnswerAdd(answer);
        }

        public List<AnswerDTO> GetAllAnswer()
        {
            AnswerCRUD answr = new AnswerCRUD();
            return answr.GetAll();
        }

        public AnswerDTO GetAnswerById(int id)
        {
            AnswerCRUD answr = new AnswerCRUD();
            return answr.GetById(id);
        }

        public List<AnswerDTO> GetAnswerByQuestionId(int questonId)
        {
            AnswerCRUD answr = new AnswerCRUD();
            return answr.AnswerGetByQuestionId(questonId);
        }

        public void UpdateAnswer(AnswerDTO answer)
        {
            AnswerCRUD answr = new AnswerCRUD();
            answr.Update(answer);
        }

        public void DeleteAnswer(int id)
        {
            AnswerCRUD answr = new AnswerCRUD();
            answr.Delete(id);
        }




        //Test_TegCRUD

        public int TestTagCreate(TestTagDTO testtag)
        {
            TestTagCRUD tt = new TestTagCRUD();
            return tt.Add(testtag);
        }

        public List<TestTagDTO> GetAll()
        {
            TestTagCRUD tt = new TestTagCRUD();
            return tt.GetAll();
        }

        public TestTagDTO GetById(int id)
        {
            TestTagCRUD tt = new TestTagCRUD();
            return tt.GetById(id);
        }

        public List<TestTagDTO> GetByTagId(int tagId)
        {
            TestTagCRUD tt = new TestTagCRUD();
            return tt.GetByTagId(tagId);
        }

        public List<TestTagDTO> GetByTestId(int testId)
        {
            TestTagCRUD tt = new TestTagCRUD();
            return tt.GetByTestId(testId);
        }

        public TestTagDTO GetByTestIdTagId(int testId, int tagId)
        {
            TestTagCRUD tt = new TestTagCRUD();
            return tt.GetByTestIdTagId(testId, tagId);
        }

        public void Update(TestTagDTO testtag)
        {
            TestTagCRUD tt = new TestTagCRUD();
            tt.Update(testtag);
        }

        public void DeleteById(int id)
        {
            TestTagCRUD tt = new TestTagCRUD();
            tt.DeleteById(id);
        }

        public void DeleteByTagId(int tagId)
        {
            TestTagCRUD tt = new TestTagCRUD();
            tt.DeleteByTagId(tagId);
        }

        public void DeleteByTestId(int testId)
        {
            TestTagCRUD tt = new TestTagCRUD();
            tt.DeleteByTestId(testId);
        }

        public void DeleteByTestIdTagId(int testId, int tagId)
        {
            TestTagCRUD tt = new TestTagCRUD();
            tt.DeleteByTestIdTagId(testId, tagId);
        }


        //FeedbackCRUD

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


        //QuestionCRUD

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

        public void DeleteQuestion(QuestionDTO question)
        {
            QuestionCRUD q = new QuestionCRUD();
            q.Delete(question.ID);
        }


        //TypeCRUD 

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


        //AttemptQuestionAnswerCRUD

        public int Add(AttemptQuestionAnswerDTO aQA)
        {
            AttemptQuestionAnswerCRUD aqa = new AttemptQuestionAnswerCRUD();
            return aqa.Add(aQA);
        }

        public List<AttemptQuestionAnswerDTO> GetAllAQA()
        {
            AttemptQuestionAnswerCRUD aqa = new AttemptQuestionAnswerCRUD();
            return aqa.GetAll();
        }

        public AttemptQuestionAnswerDTO GetByIdAQA(int id)
        {
            AttemptQuestionAnswerCRUD aqa = new AttemptQuestionAnswerCRUD();
            return aqa.GetById(id);
        }

        public List<AttemptQuestionAnswerDTO> GetByAttemptID(int attemptId)
        {
            AttemptQuestionAnswerCRUD aqa = new AttemptQuestionAnswerCRUD();
            return aqa.GetByAttemptID(attemptId);
        }

        public List<AttemptQuestionAnswerDTO> GetByQuestionID(int questionId)
        {
            AttemptQuestionAnswerCRUD aqa = new AttemptQuestionAnswerCRUD();
            return aqa.GetByQuestionID(questionId);
        }

        public List<AttemptQuestionAnswerDTO> GetByAnswerID(int answerId)
        {
            AttemptQuestionAnswerCRUD aqa = new AttemptQuestionAnswerCRUD();
            return aqa.GetByAnswerID(answerId);
        }

        public void DeleteAQA(int id)
        {
            AttemptQuestionAnswerCRUD aqa = new AttemptQuestionAnswerCRUD();
            aqa.Delete(id);
        }

        public void DeleteByAttemptID(int attemptId)
        {
            AttemptQuestionAnswerCRUD aqa = new AttemptQuestionAnswerCRUD();
            aqa.DeleteByAttemptID(attemptId);
        }

        public void DeleteByQuestionID(int questionId)
        {
            AttemptQuestionAnswerCRUD aqa = new AttemptQuestionAnswerCRUD();
            aqa.DeleteByQuestionID(questionId);
        }

        public void DeleteByAnswerID(int answerId)
        {
            AttemptQuestionAnswerCRUD aqa = new AttemptQuestionAnswerCRUD();
            aqa.DeleteByAnswerID(answerId);
        }


        //From FeedbackManager

        public List<FeedbackSortByDataTimeDTO> feedbackSortByDataTime(QuestionDTO question)
        {
            FeedbackManager fb = new FeedbackManager();
            return fb.FeedbackSortByDataTime(question);
        }


        //From TestManager

        public List<SearchTestByTagDTO> GetTestVSTagSearchOr(string tag1, string tag2, string tag3)
        {
            TestManager tm = new TestManager();
            return tm.GetTestVSTagSearchOr(tag1, tag2, tag3);
        }

        public List<SearchTestByTagDTO> GetTestVSTagSearchAnd(string tag1, string tag2, string tag3)
        {
            TestManager tm = new TestManager();
            return tm.GetTestVSTagSearchAnd(tag1, tag2, tag3);
        }

        public List<Question_AnswerDTO> AnswerGetCorrectByTestID(TestDTO test)
        {
            TestManager managerAnswer = new TestManager();
            return managerAnswer.GetCorrectAnswerByTestID(test);
        }

        public List<TagDTO> GetTagsInTest(TestDTO tests)
        {
            TestManager test = new TestManager();
            return test.GetTestTags(tests);
        }


        //From QuestionManager

        public void QuestionDeleteFromTest(int questionId)
        {
            QuestionManager question = new QuestionManager();
            question.DeleteQuestionFromTest(questionId);
        }

        // TestCRUD

        public int AddTest(TestDTO test)
        {
            TestCRUD ts = new TestCRUD();
            return ts.Add(test);
        }

        public List<TestDTO> GetAllTest()
        {
            TestCRUD ts = new TestCRUD();
            return ts.GetAll();
        }

        public TestDTO GetByIdTest(int id)
        {
            TestCRUD ts = new TestCRUD();
            return ts.GetById(id);
        }

        public void UpdateTest(TestDTO test)
        {
            TestCRUD ts = new TestCRUD();
            ts.Update(test);
        }

        public void DeleteTest(int id)
        {
            TestCRUD ts = new TestCRUD();
            ts.Delete(id);
        }

        //TagCRUD
        public int AddTag(TagDTO tag) 
        {
            TagCRUD tg = new TagCRUD();
            return tg.Add(tag);
        } 

    }
}
