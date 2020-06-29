using Dapper;
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
        public List<TestDTO> GetAllTests()      
        {
            TestCRUD tests = new TestCRUD();
            return tests.GetAll();
        }

        public List<TestDTO> GetTestsFoundByTagOr(params string[] tag)    
        {
            TestManager tests = new TestManager();
            return tests.GetTestVSTagSearchOr(tag);
        }

        public List<TestDTO> GetTestsFoundByTagAnd(params string[] tag)    
        {
            TestManager tests = new TestManager();
            return tests.GetTestVSTagSearchAnd(tag);
        }        

        public List<FeedbackDTO> GetProcessedFeedbacks()       
        {
            FeedbackManager feedbacks = new FeedbackManager();
            return feedbacks.GetProcessedFeedback();
        }

        public List<FeedbackDTO> GetNotProcessedFeedbacks()    
        {
            FeedbackManager feedbacks = new FeedbackManager();
            return feedbacks.GetNotProcessedFeedback();
        }

        public List<FeedbackDTO> GetAllFeedbacks()       
        {
            FeedbackCRUD feedbacks = new FeedbackCRUD();
            return feedbacks.GetAll();
        }

        public List<FeedbackDTO> GetFeedbacksByTestId(int testId)    
        {
            FeedbackManager feedbacks = new FeedbackManager();
            return feedbacks.GetFeedbackByTest(testId);
        }

        public List<FeedbackDTO> GetFeedbacksByPeriod(DateTime periodStart, DateTime periodEnd)  
        {
            FeedbackManager feedbacks = new FeedbackManager();
            return feedbacks.GetFeedbackByDate(periodStart, periodEnd);
        }

        public List<TagDTO> GetAllTags()     
        {
            TagCRUD tags = new TagCRUD();
            return tags.GetAll();
        }

        public int AddTag(TagDTO tagDto)       
        {
            TagCRUD tag = new TagCRUD();
            return tag.Add(tagDto);
        }

        public void UpdateTagById(TagDTO tagDto)   
        {
            TagCRUD tag = new TagCRUD();
            tag.Update(tagDto);
        }

        public void DeleteTagById(int id)       
        {
            TagCRUD tag = new TagCRUD();
            tag.Delete(id);
        }

        public TestTagDTO GetTestByTag(int testId, int tagId)       //вывод связи тест-тег   
        {
            TestTagCRUD tag = new TestTagCRUD();
            return tag.GetByTestIdTagId(testId, tagId); 
        }
       
        public int AddTest(TestDTO testDto)     
        {
            TestCRUD test = new TestCRUD();
            return test.Add(testDto);
        }

        public int UpdateTestById(TestDTO testDto)   
        {
            TestCRUD test = new TestCRUD();
            return test.Update(testDto);
        }

        public int DeleteTestById(int id)       
        {
            TestCRUD test = new TestCRUD();
            return test.Delete(id);
        }        

        public TestDTO GetTestById(int id)    
        {
            TestCRUD ts = new TestCRUD();
            return ts.GetById(id);
        }

        public List<QuestionDTO> GetQuestionsByTestID(int testId)  
        {
            QuestionCRUD q = new QuestionCRUD();
            return q.GetByTestId(testId);
        }

        public List<AnswerDTO> GetAllAnswersInTest(int testId)        
        {
            TestManager answers = new TestManager();
            return answers.GetAllAnswersInTest(testId);
        }

        public List<TagDTO> GetTagsInTest(int testId)         
        {
            TestManager tags = new TestManager();
            return tags.GetTestTags(testId);
        }

        public TagDTO GetTagById(int tagId)         //вывод тега по ID  
        {
            TagCRUD tags = new TagCRUD();
            return tags.GetById(tagId);
        }

        public List<TagDTO> GetTagsWhichAreNotInTest(int testId)    
        {
            TestManager tags = new TestManager();
            return tags.GetTagsWhichAreNotInTest(testId);
        }

        public int DeleteByTestIdTagId(int testId, int tagId)    
        {
            TestTagCRUD tag = new TestTagCRUD();
            tag.DeleteByTestIdTagId(testId, tagId);
            return testId;
        }

        public int TestTagCreate(TestTagDTO testtag)        
        {
            TestTagCRUD tag = new TestTagCRUD();
            return tag.Add(testtag);
        }        

        public int AddQuestion(QuestionDTO questionDto)       
        {
            QuestionCRUD question = new QuestionCRUD();
            return question.Add(questionDto);
        }

        public QuestionDTO GetQuestionById(int id)   
        {
            QuestionCRUD question = new QuestionCRUD();
            return question.GetById(id);
        }

        public void UpdateQuestionById(QuestionDTO questionDto)   
        {
            QuestionCRUD question = new QuestionCRUD();
            question.Update(questionDto);
        }

        public int DeleteQuestionById(int questionId)  
        {
            QuestionCRUD question = new QuestionCRUD();
            question.Delete(questionId);
            return questionId;
        }

        public AnswerDTO GetAnswerById(int answerId)     // вывод ответа по ID   
        {
            AnswerCRUD answer = new AnswerCRUD();
            return answer.GetById(answerId);
        }

        public int AddAnswer(AnswerDTO answerDto)     
        {
            AnswerCRUD answer = new AnswerCRUD();
            return answer.Add(answerDto);
        }

        public List<AnswerDTO> GetAnswerByQuestionId(int questonId)     
        {
            AnswerCRUD answers = new AnswerCRUD();
            return answers.GetByQuestionId(questonId);
        }

        public void UpdateAnswerById(AnswerDTO answerDto)    
        {
            AnswerDTO a =new AnswerDTO();
            AnswerCRUD answer = new AnswerCRUD();
            answer.Update(answerDto);
        }

        public void DeleteAnswerById(int id)    
        {
            AnswerCRUD answer = new AnswerCRUD();
            answer.Delete(id);
        }

        public FeedbackDTO GetFeedbackById(int feedbackId)  //проверка
        {
            FeedbackCRUD feedback = new FeedbackCRUD();
            return feedback.GetById(feedbackId);
        }

        public FeedbackQuestionDTO GetFeedbackWithQuestion(int id)     
        {
            FeedbackManager feedback = new FeedbackManager();
            return feedback.GetFeedbackWithQuestion(id);
        }

        public List<AnswerDTO> GetAllAnswersByFeedbackId(int feedbackId)   
        {
            FeedbackManager answer = new FeedbackManager();
            return answer.GetAllAnswersByFeedbackId(feedbackId);
        }

        public int UpdateProcessedInFeedback(int id)      
        {
            FeedbackManager feedback = new FeedbackManager();
            return feedback.UpdateProcessedInFeedback(id);
        }
    }
}
