using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestingSystem.Data;
using TestingSystem.Data.DTO;
using TestingSystem.API.Models.Output;
using TestingSystem.API.Models.Input;

namespace TestingSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestsController : ControllerBase
    {
        private readonly ILogger<TestsController> _logger;

        public TestsController(ILogger<TestsController> logger)
        {
            _logger = logger;
        }


        //Запросы на основной странице "Test" (список тестов/список фидбэков/список тэгов)
        
        [HttpGet("Author")]  //вывод списка всех тестов

        public List<TestOutputModel> GetAllTest()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tests = new AuthorDataAccess();
            return mapper.TestDTOToTestModelList(tests.GetAllTest());
        }

        [HttpGet("SearchTest/Author")]  //поиск теста по тегу 

        public List<TestOutputModel> GetTestVSTagSearch([FromBody] SearchTestByTagInputModel sttim)
        {
            bool caseSwitch =sttim.SwitchValue;
            Mapper mapper = new Mapper();
            AuthorDataAccess search = new AuthorDataAccess();

            switch (caseSwitch)
            {
                case true:
                    return mapper.TestDTOToTestModelList(search.GetTestVSTagSearchAnd(sttim.Tag));
                case false:                  
                    return mapper.TestDTOToTestModelList(search.GetTestVSTagSearchOr(sttim.Tag));
            }
        }


        //[HttpGet("SearchTestByTagOr/Author")]  //поиск теста по тегу     

        //public List<TestOutputModel> GetTestVSTagSearchOr(params string[] tag)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess tests = new AuthorDataAccess();
        //    return mapper.SearchTestByTagDTOToTestModelList(tests.GetTestVSTagSearchOr(tag));
        //}

        //[HttpGet("SearchTestByTagAnd/Author")]  //поиск теста по тегу     

        //public List<TestOutputModel> GetTestVSTagSearchAnd(params string[] tag)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess tests = new AuthorDataAccess();
        //    return mapper.SearchTestByTagDTOToTestModelList(tests.GetTestVSTagSearchAnd(tag));
        //}

        [HttpGet("ProcessedFeedbacks/Author")]    //список обработанных фидбэков

        public List<FeedbackOutputModel> GetProcessedFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return mapper.FeedbackDTOToFeedbackModelList(feedbacks.GetProcessedFeedbacks());
        }

        [HttpGet("NotProcessedFeedbacks/Author")]    //список необработанных фидбэков

        public List<FeedbackOutputModel> GetNotProcessedFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return mapper.FeedbackDTOToFeedbackModelList(feedbacks.GetNotProcessedFeedbacks());
        }

        [HttpGet("Feedbacks/Author")]    //список всех фидбэков

        public List<FeedbackOutputModel> GetAllFeedbacks()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return mapper.FeedbackDTOToFeedbackModelList(feedbacks.GetAllFeedbacks());
        }

        [HttpGet("FeedbacksByTest/Author")]    //список фидбэков конкретных тестов

        public List<FeedbackOutputModel> GetFeedbackByTest(int testId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return mapper.FeedbackDTOToFeedbackModelList(feedbacks.GetFeedbackByTest(testId));
        }

        [HttpGet("FeedbacksByDate/Author")]    //список фидбэков конкретных дат

        public List<FeedbackOutputModel> GetFeedbackByDate(DateTime dateTime1, DateTime dateTime2)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess feedbacks = new AuthorDataAccess();
            return mapper.FeedbackDTOToFeedbackModelList(feedbacks.GetFeedbackByDate(dateTime1, dateTime2));
        }

        [HttpGet("Tags/Author")]      //cписок всех тегов

        public List<TagOutputModel> GetAllTags()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tags = new AuthorDataAccess();
            return mapper.TagDTOToTagModelList(tags.GetAllTag());
        }

        [HttpPost("Tags/Author")]      //создание тега

        public int PostTag([FromBody]TagInputModel tagmodel)
        {
            Mapper mapper = new Mapper();
            TagDTO tagdto = mapper.TagInputModelToTagDTO(tagmodel);
            AuthorDataAccess tag = new AuthorDataAccess();
            return tag.AddTag(tagdto);            
        }

        [HttpPut("Tags/Author")]      //изменение конкретного тега

        public void PutTag([FromBody]TagInputModel tagmodel)
        {
            Mapper mapper = new Mapper();
            TagDTO tagdto = mapper.TagInputModelToTagDTO(tagmodel);
            AuthorDataAccess tag = new AuthorDataAccess();
            tag.UpdateTag(tagdto);
        }

        [HttpDelete("Tags/{tagId}/Author")]    //удаление конкретного тега

        public void DeleteTag(int tagId)
        {
            AuthorDataAccess tag = new AuthorDataAccess();
            tag.DeleteTag(tagId);
        }



        //Запросы на странице конкретного теста "Id" (тест с информацией, вопросы, ответы теста)

        [HttpPost("Author")]       //создание теста

        public int PostTest(TestInputModel testmodel)
        {
            Mapper mapper = new Mapper();
            TestDTO testdto = mapper.TestInputModelToTestDTO(testmodel);
            AuthorDataAccess test = new AuthorDataAccess();
            return test.AddTest(testdto);            
        }

        [HttpPut("Author")]        //изменение информации о конкретном тесте

        public int PutTestById([FromBody]TestInputModel testmodel)
        {
            Mapper mapper = new Mapper();
            TestDTO testdto = mapper.TestInputModelToTestDTO(testmodel);
            AuthorDataAccess test = new AuthorDataAccess();
            return test.UpdateTest(testdto);            
        }

        [HttpDelete("{testId}/Author")]       //удаление конкретного тесте

        public int DeleteTestById(int testId)
        {
            AuthorDataAccess test = new AuthorDataAccess();
            return test.DeleteTest(testId);
        }

        [HttpGet("{testId}/Author")]     //полная информация о тесте
        public TestOutputModel GetTestInfo(int testId) 
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess ada = new AuthorDataAccess();
            TestOutputModel model = mapper.TestDTOToTestOutputModel(ada.GetByIdTest(testId));
            model.Questions = mapper.QuestionDTOToQuestionModelList(ada.GetQuestionsByTestID(testId));
            model.Tags = mapper.TagDTOToTagModelList(ada.GetTagsInTest(testId));
            foreach(QuestionOutputModel qom in model.Questions)
            {
                qom.Answers = mapper.AnswerDTOToAnswerModelList(ada.GetAnswerByQuestionId(qom.ID));
            }
            return model;
        }

        [HttpGet("{testId}/TestInfo/Author")]          //вывод информации о конкретном тесте
        public TestOutputModel GetByIdTest(int testId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess test = new AuthorDataAccess();
            return mapper.TestDTOToTestOutputModel(test.GetByIdTest(testId));            
        }

        [HttpGet("{testId}/Questions/Author")]          //вывод всех вопросов из конкретного теста

        public List<QuestionOutputModel> GetQuestionsByTestID(int testId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess questions = new AuthorDataAccess();
            return mapper.QuestionDTOToQuestionModelList(questions.GetQuestionsByTestID(testId));            
        }

        [HttpGet("{testId}/Answers/Author")]          //вывод всех ответов из конкретного теста

        public List<AnswerOutputModel> GetAnswersByTestID(int testId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess answers = new AuthorDataAccess();
            return mapper.AnswerDTOToAnswerModelList(answers.GetAllAnswersInTest(testId));
        }

        [HttpGet("{testId}/Tags/Author")]         //вывод всех тегов конкретного теста

        public List<TagOutputModel> GetTagsInTest(int testId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tags = new AuthorDataAccess();            
            return mapper.TagDTOToTagModelList(tags.GetTagsInTest(testId));            
        }

        [HttpGet("{testId}/MissingTags/Author")]          //вывод тегов, которых нет в тесте, для добавления

        public List<TagOutputModel> GetTagsWhichAreNotInTest(int testId)
        {
            Mapper mapper = new Mapper();            
            AuthorDataAccess tags = new AuthorDataAccess();
            return mapper.TagDTOToTagModelList(tags.GetTagsWhichAreNotInTest(testId));
        }

        [HttpDelete("{testId}/Tags/{tagid}/Author")]     //удаление тэга из конкретного теста

        public void DeleteTagFromTest(int testId, int tagId)
        {
            AuthorDataAccess tag = new AuthorDataAccess();
            tag.DeleteByTestIdTagId(testId, tagId);
        }

        [HttpPost("Tags/Author")]      //добавление существующего тэга к конкретному тесту (создаем новую связь тест-тэг)

        public int PostTagInTest(TestTagInputModel testtagmodel)
        {
            Mapper mapper = new Mapper();
            TestTagDTO testtagdto = mapper.TestTagInputModelToTestTagDTO(testtagmodel);
            AuthorDataAccess tag = new AuthorDataAccess();
            return tag.TestTagCreate(testtagdto);
        }


        /* 
        //страница с тэгами

        [HttpPost("{Testid}/Tags/Author")] //добавление тега к конкретному тесту

        public int PostTagByTest(TestTagDTO testtag) 
        {
            AuthorDataAccess tt = new AuthorDataAccess();
            return tt.TestTagCreate(testtag);
        }

        [HttpDelete("{Testid}/Tags/{tagId}/Author")] //удаление тега из конкретного теста

        public void DeleteByTestIdTagId(int testId, int tagId)
        {
            AuthorDataAccess tt = new AuthorDataAccess();
            tt.DeleteByTestIdTagId(testId, tagId);
        }
        */

        // создание вопроса с ответами
        [HttpPost("{Testid}/{quId}/Author")] // создание вопроса конкретного теста

        public int PostQuestion(QuestionDTO question)
        {
            AuthorDataAccess aq = new AuthorDataAccess();
            return aq.AddQuestion(question);
        }

        [HttpPost("{Testid}/{quId}/Author")] // создание ответа для вопроса

        public int PostAnswer(AnswerDTO answer)
        {
            AuthorDataAccess aa = new AuthorDataAccess();
            return aa.AddAnswer(answer);
        }

        // изменение вопроса с ответами

        [HttpPut("{Testid}/{quId}/Author")] // изменение конкретного вопроса

        public void PutQuestion(QuestionDTO question)
        {
            AuthorDataAccess uq = new AuthorDataAccess();
            uq.UpdateQuestion(question);
        }

        [HttpPut("{Testid}/{quId}/Author")] // изменение ответа конкретного вопроса

        public void PutAnswer(AnswerDTO answer)
        {
            AuthorDataAccess ua = new AuthorDataAccess();
            ua.UpdateAnswer(answer);
        }

        // вывод вопроса с ответами

        [HttpGet("{Testid}/{quId}/Author")] // вывод конкретного вопроса

        public QuestionDTO GetQuestionById([FromBody] int id)
        {
            AuthorDataAccess gq = new AuthorDataAccess();
            return gq.GetQuestionById(id);
        }

        [HttpGet("{Testid}/{quId}/Author")] // вывод ответы к конкретному вопросу

        public List<AnswerDTO> GetAnswerByQuestionId([FromBody] int questonId)
        {
            AuthorDataAccess ga = new AuthorDataAccess();
            return ga.GetAnswerByQuestionId(questonId);
        }

        // удаление вопроса с ответами

        [HttpDelete("{Testid}/{quId}/Author")]

        public int DeleteQuestionFromTest([FromBody] int questionId)
        {
            AuthorDataAccess dq = new AuthorDataAccess();
            dq.DeleteQuestionFromTest(questionId);
            return questionId;
        }

        [HttpDelete("{Testid}/{quId}/Author")]

        public void DeleteAnswer([FromBody] int id)
        {
            AuthorDataAccess da = new AuthorDataAccess();
            da.DeleteAnswer(id);
        }
    }
}