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
        
        public void Update(TestTagDTO testtag)
        {
            TestTagCRUD tt = new TestTagCRUD();
            tt.Update(testtag);
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

        public List<FeedbackDTO> GetAllFeedback()
        {
            FeedbackCRUD fb = new FeedbackCRUD();
            return fb.FeedbackGetAll();
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

        //public int AddType(TypeDTO type)
        //{
        //    TypeCRUD typeCRUD = new TypeCRUD();
        //    return typeCRUD.Add(type);
        //}

        //public List<TypeDTO> GetAllTypes()
        //{
        //    TypeCRUD typeCRUD = new TypeCRUD();
        //    return typeCRUD.GetAll();
        //}        

        //public void UpdateType(TypeDTO type)
        //{
        //    TypeCRUD typeCRUD = new TypeCRUD();
        //    typeCRUD.Update(type);
        //}

        //public void DeleteType(TypeDTO type)
        //{
        //    TypeCRUD typeCRUD = new TypeCRUD();
        //    typeCRUD.Delete(type.ID);
        //}
        

        //TestCRUD

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

        public int UpdateTest(TestDTO test)
        {
            TestCRUD ts = new TestCRUD();
            return ts.Update(test);
        }


        //TagCRUD
        public int AddTag(TagDTO tag)
        {
            TagCRUD tg = new TagCRUD();
            return tg.Add(tag);
        }
        
        public void UpdateTag(TagDTO tag)
        {
            TagCRUD tg = new TagCRUD();
            tg.Update(tag);
        }

        public void DeleteTag(int id)
        {
            TagCRUD tg = new TagCRUD();
            tg.Delete(id);
        }


        //From FeedbackManager

        



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

        public List<TagDTO> GetTagsInTest(TestDTO tests)
        {
            TestManager test = new TestManager();
            return test.GetTestTags(tests);
        }

        public void DeleteTest(TestDTO test)
        {
            TestManager tm = new TestManager();
            tm.DeleteTest(test.ID);
        }


        //From QuestionManager

        public int DeleteQuestionFromTest(int questionId)
        {
            QuestionManager question = new QuestionManager();
            question.DeleteQuestionFromTest(questionId);
            return questionId;
        }
        

        //From AttemptManager

       
    }
}
