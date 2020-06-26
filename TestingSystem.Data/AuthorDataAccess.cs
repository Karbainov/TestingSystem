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
        //Запросы на основной странице "Test" (список тестов/список фидбэков/список тэгов)

        public List<TestDTO> GetAllTests()       //вывод списка всех тестов
        {
            TestCRUD tests = new TestCRUD();
            return tests.GetAll();
        }

        public List<TestDTO> GetTestsVSTagSearchOr(params string[] tag)    //ищем тесты по тэгу(или)
        {
            TestManager tests = new TestManager();
            return tests.GetTestVSTagSearchOr(tag);
        }

        public List<TestDTO> GetTestsVSTagSearchAnd(params string[] tag)     //ищем тесты по тэгу(и)
        {
            TestManager tests = new TestManager();
            return tests.GetTestVSTagSearchAnd(tag);
        }        

        public List<FeedbackDTO> GetProcessedFeedbacks()       //список обработанных фидбэков (сортировка по дате убыв.)
        {
            FeedbackManager feedbacks = new FeedbackManager();
            return feedbacks.GetProcessedFeedback();
        }

        public List<FeedbackDTO> GetNotProcessedFeedbacks()    //список необработанных фидбэков (сортировка по дате)
        {
            FeedbackManager feedbacks = new FeedbackManager();
            return feedbacks.GetNotProcessedFeedback();
        }

        public List<FeedbackDTO> GetAllFeedbacks()       //список всех фидбэков (сортировка по дате убыв.)
        {
            FeedbackCRUD feedbacks = new FeedbackCRUD();
            return feedbacks.GetAll();
        }

        public List<FeedbackDTO> GetFeedbackByTestId(int testId)    //список фидбэков конкретного теста (сортировка по дате убыв.)
        {
            FeedbackManager feedbacks = new FeedbackManager();
            return feedbacks.GetFeedbackByTest(testId);
        }

        public List<FeedbackDTO> GetFeedbackByPeriod(DateTime periodStart, DateTime periodEnd)  //список фидбэков конкретных дат (сортировка по дате)
        {
            FeedbackManager feedbacks = new FeedbackManager();
            return feedbacks.GetFeedbackByDate(periodStart, periodEnd);
        }

        public List<TagDTO> GetAllTags()     //список всех тэгов
        {
            TagCRUD tags = new TagCRUD();
            return tags.GetAll();
        }

        public int AddTag(TagDTO tg)       //создать тэг
        {
            TagCRUD tag = new TagCRUD();
            return tag.Add(tg);
        }

        public void UpdateTag(TagDTO tg)   //редактировать тэг
        {
            TagCRUD tag = new TagCRUD();
            tag.Update(tg);
        }

        public void DeleteTag(int id)       //удалить тэг
        {
            TagCRUD tag = new TagCRUD();
            tag.Delete(id);
        }

        public TestTagDTO GetTestByTag(int testId, int tagId)       //вывод связи тест-тег   ???????
        {
            TestTagCRUD tag = new TestTagCRUD();
            return tag.GetByTestIdTagId(testId, tagId); 
        }



        //Запросы на странице конкретного теста "Id" (тест с информацией, вопросы, ответы теста)

        public int AddTest(TestDTO t)     //добавить новый тест
        {
            TestCRUD test = new TestCRUD();
            return test.Add(t);
        }

        public int UpdateTestById(TestDTO t)   //изменить информацию о тесте
        {
            TestCRUD test = new TestCRUD();
            return test.Update(t);
        }

        public int DeleteTestById(int id)       //удалить тест
        {
            TestCRUD test = new TestCRUD();
            return test.Delete(id);
        }        

        public TestDTO GetTestById(int id)    //вывод конкретного теста с полной информацией
        {
            TestCRUD ts = new TestCRUD();
            return ts.GetById(id);
        }

        public List<QuestionDTO> GetQuestionsByTestID(int testId)  //список всех вопросов теста 
        {
            QuestionCRUD q = new QuestionCRUD();
            return q.GetByTestId(testId);
        }

        public List<AnswerDTO> GetAllAnswersInTest(int testid)        //список всех ответов теста с указанием айди вопроса
        {
            TestManager answers = new TestManager();
            return answers.GetAllAnswersInTest(testid);
        }

        public List<TagDTO> GetTagsInTest(int testId)         //список всех тэгов теста
        {
            TestManager tags = new TestManager();
            return tags.GetTestTags(testId);
        }

        public TagDTO GetTagById(int tagId)         //вывод тега по ID  ????????
        {
            TagCRUD tags = new TagCRUD();
            return tags.GetById(tagId);
        }

        public List<TagDTO> GetTagsWhichAreNotInTest(int testId)    //список тэгов, которых нет в этом тесте, чтобы выбрать для добавления
        {
            TestManager tags = new TestManager();
            return tags.GetTagsWhichAreNotInTest(testId);
        }

        public int DeleteByTestIdTagId(int testId, int tagId)    //удалить тэг из конкретного теста
        {
            TestTagCRUD tag = new TestTagCRUD();
            tag.DeleteByTestIdTagId(testId, tagId);
            return testId;
        }

        public int TestTagCreate(TestTagDTO testtag)        //добавить тэг из списка тэгов к конкретному тесту
        {
            TestTagCRUD tag = new TestTagCRUD();
            return tag.Add(testtag);
        }


        //Запросы на странице конкретного вопроса у теста "Id/QuestionId" (вопрос с полной информацией, ответы на этот вопрос)

        public int AddQuestion(QuestionDTO q)       //создать вопрос к тесту
        {
            QuestionCRUD question = new QuestionCRUD();
            return question.Add(q);
        }

        public QuestionDTO GetQuestionById(int id)   //вывести вопрос теста
        {
            QuestionCRUD question = new QuestionCRUD();
            return question.GetById(id);
        }

        public void UpdateQuestionById(QuestionDTO question)   //редактировать вопрос теста с пересчетом результатов
        {
            QuestionCRUD q = new QuestionCRUD();
            q.Update(question);
        }

        public int DeleteQuestionById(int questionId)  //удалить вопрос из теста с пересчетом результатов
        {
            QuestionCRUD question = new QuestionCRUD();
            question.Delete(questionId);
            return questionId;
        }

        public AnswerDTO GetAnswerById(int answerId)     // вывод ответа по ID   ????????
        {
            AnswerCRUD answer = new AnswerCRUD();
            return answer.GetById(answerId);
        }


        public int AddAnswer(AnswerDTO ans)     //добавить ответ к вопросу
        {
            AnswerCRUD answer = new AnswerCRUD();
            return answer.Add(ans);
        }

        public List<AnswerDTO> GetAnswerByQuestionId(int questonId)     //список ответов на конкретный вопрос
        {
            AnswerCRUD answers = new AnswerCRUD();
            return answers.GetByQuestionId(questonId);
        }

        public void UpdateAnswerById(AnswerDTO ans)    //редактировать ответ
        {
            AnswerDTO a =new AnswerDTO();
            AnswerCRUD answer = new AnswerCRUD();
            answer.Update(ans);
        }

        public void DeleteAnswerById(int id)    //удалить ответ
        {
            AnswerCRUD answer = new AnswerCRUD();
            answer.Delete(id);
        }


        //Запросы на странице конкретного фидбэка "FeedbackId" (вся информация по фидбэку)

        public FeedbackDTO GetFeedbackById(int feedbackId)       // вывод фитбека по его ID
        {
            FeedbackCRUD feedback = new FeedbackCRUD();
            return feedback.GetById(feedbackId);
        }

        public FeedbackQuestionDTO GetFeedbackWithQuestion(int id)     //вывод фидбэка (с именем пользователя, названием теста и вопросом)
        {
            FeedbackManager feedback = new FeedbackManager();
            return feedback.GetFeedbackWithQuestion(id);
        }

        public List<AnswerDTO> GetAllAnswersByFeedbackId(int feedbackId)   //список ответов на вопрос, к которому написан фидбэк
        {
            FeedbackManager answer = new FeedbackManager();
            return answer.GetAllAnswersByFeedbackId(feedbackId);
        }

        public int UpdateProcessedInFeedback(int id)      //отметить, что фидбэк просмотрен (можно вернуть на непросмотренный)
        {
            FeedbackManager feedback = new FeedbackManager();
            return feedback.UpdateProcessedInFeedback(id);
        }









        //Методы, которые могут пригодиться?

        public void DeleteByTagId(int tagId)   //удалить тэг из всех тестов
        {
            TestTagCRUD tt = new TestTagCRUD();
            tt.DeleteByTagId(tagId);
        }

        public void DeleteByTestId(int testId)   //удалить все тэги из теста
        {
            TestTagCRUD tt = new TestTagCRUD();
            tt.DeleteByTestId(testId);
        }

        public List<QuestionDTO> GetAllQuestions()   //список всех существующих вопросов
        {
            QuestionCRUD q = new QuestionCRUD();
            return q.GetAll();
        }        

        

        public List<QuestionDTO> GetQuestionsByTypeId(int typeId)  //список всех вопросов по конкретному типу
        {
            QuestionCRUD q = new QuestionCRUD();
            return q.GetByTypeId(typeId);
        }

        public int AddType(TypeDTO type)   //добавить тип вопросов
        {
            TypeCRUD typeCRUD = new TypeCRUD();
            return typeCRUD.Add(type);
        }

        public List<TypeDTO> GetAllTypes()  //список всех типов вопросов
        {
            TypeCRUD typeCRUD = new TypeCRUD();
            return typeCRUD.GetAll();
        }

        public void UpdateType(TypeDTO type)   //поменять тип вопросов
        {
            TypeCRUD typeCRUD = new TypeCRUD();
            typeCRUD.Update(type);
        }

        public void DeleteType(TypeDTO type)  //удалить тип вопросов
        {
            TypeCRUD typeCRUD = new TypeCRUD();
            typeCRUD.Delete(type.ID);
        }        
    }
}
