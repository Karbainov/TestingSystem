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
    public class TestsController : Controller
    {
        private readonly ILogger<TestsController> _logger;

        public TestsController(ILogger<TestsController> logger)
        {
            _logger = logger;
        }


        //Запросы на основной странице "Tests" (список тестов/список тэгов)
        
        [HttpGet("Author")]    //вывод списка всех тестов
        public IActionResult GetAllTest()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tests = new AuthorDataAccess();
            return Json(mapper.TestDTOToTestModelList(tests.GetAllTest()));
        }

        [HttpGet("search-test-by-tags/Author")]    //поиск теста по тегу 
        public IActionResult GetTestVSTagSearch([FromBody] SearchTestByTagInputModel sttim)
        {
            bool caseSwitch =sttim.SwitchValue;
            Mapper mapper = new Mapper();
            AuthorDataAccess search = new AuthorDataAccess();

            switch (caseSwitch)
            {
                case true:
                    return Json(mapper.TestDTOToTestModelList(search.GetTestVSTagSearchAnd(sttim.Tag)));
                case false:                  
                    return Json(mapper.TestDTOToTestModelList(search.GetTestVSTagSearchOr(sttim.Tag)));
            }
        }        

        [HttpGet("tags/Author")]      //cписок всех тегов
        public List<TagOutputModel> GetAllTags()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tags = new AuthorDataAccess();
            return mapper.TagDTOToTagModelList(tags.GetAllTag());
        }

        [HttpPost("tag/Author")]      //создание тега
        public int PostTag([FromBody]TagInputModel tagmodel)     //спросить у Макса
        {
            Mapper mapper = new Mapper();
            TagDTO tagdto = mapper.TagInputModelToTagDTO(tagmodel);
            AuthorDataAccess tag = new AuthorDataAccess();
            return tag.AddTag(tagdto);            
        }

        [HttpPut("tag/Author")]      //изменение конкретного тега
        public void PutTag([FromBody]TagInputModel tagmodel)
        {
            Mapper mapper = new Mapper();
            TagDTO tagdto = mapper.TagInputModelToTagDTO(tagmodel);
            AuthorDataAccess tag = new AuthorDataAccess();
            tag.UpdateTag(tagdto);
        }

        [HttpDelete("tag/{tagId}/Author")]    //удаление конкретного тега
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

        [HttpPut("{testId}/Author")]        //изменение информации о конкретном тесте
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

        //[HttpGet("{testId}/test-info/Author")]          //вывод информации о конкретном тесте
        //public TestOutputModel GetByIdTest(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess test = new AuthorDataAccess();
        //    return mapper.TestDTOToTestOutputModel(test.GetByIdTest(testId));            
        //}

        //[HttpGet("{testId}/questions/Author")]          //вывод всех вопросов из конкретного теста
        //public List<QuestionOutputModel> GetQuestionsByTestID(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess questions = new AuthorDataAccess();
        //    return mapper.QuestionDTOToQuestionModelList(questions.GetQuestionsByTestID(testId));            
        //}

        //[HttpGet("{testId}/answers/Author")]          //вывод всех ответов из конкретного теста
        //public List<AnswerOutputModel> GetAnswersByTestID(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess answers = new AuthorDataAccess();
        //    return mapper.AnswerDTOToAnswerModelList(answers.GetAllAnswersInTest(testId));
        //}

        //[HttpGet("{testId}/tags/Author")]         //вывод всех тегов конкретного теста
        //public List<TagOutputModel> GetTagsInTest(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess tags = new AuthorDataAccess();            
        //    return mapper.TagDTOToTagModelList(tags.GetTagsInTest(testId));            
        //}

        [HttpGet("{testid}/missing-tags/Author")]          //вывод тегов, которых нет в тесте, для добавления
        public List<TagOutputModel> GetTagsWhichAreNotInTest(int testid)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tags = new AuthorDataAccess();
            return mapper.TagDTOToTagModelList(tags.GetTagsWhichAreNotInTest(testId));
        }

        [HttpDelete("{testid}/tag/{tagid}/Author")]     //удаление тэга из конкретного теста
        public void DeleteTagFromTest(int testid, int tagid)
        {
            AuthorDataAccess tag = new AuthorDataAccess();
            tag.DeleteByTestIdTagId(testid, tagid);
        }

        [HttpPost("{testId}/tag/{tagid}/Author")]      //добавление существующего тэга к конкретному тесту (создаем новую связь тест-тэг)
        public int PostTagInTest(TestTagInputModel testtagmodel)
        {
            Mapper mapper = new Mapper();
            TestTagDTO testtagdto = mapper.TestTagInputModelToTestTagDTO(testtagmodel);
            AuthorDataAccess tag = new AuthorDataAccess();
            return tag.TestTagCreate(testtagdto);
        }



        //Запросы на странице конкретного вопроса у теста "Id/QuestionId" (вопрос с полной информацией, ответы на этот вопрос)
        
        [HttpPost("{testid}/question/Author")]       // создание вопроса конкретного теста
        public int PostQuestion(QuestionInputModel questionmodel)
        {
            Mapper mapper = new Mapper();
            QuestionDTO questiondto = mapper.QuestionInputModelToQuestionDTO(questionmodel);
            AuthorDataAccess question = new AuthorDataAccess();
            return question.AddQuestion(questiondto);            
        }

        //[HttpGet("{testid}/question/{quid}/Author")]       // вывод вопроса
        //public QuestionOutputModel GetQuestionById([FromBody] int quid)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess question = new AuthorDataAccess();
        //    return mapper.QuestionDTOToQuestionOutputModel(question.GetQuestionById(quid));            
        //}

        [HttpPut("question/{quid}/Author")]      // изменение конкретного вопроса из теста
        public void PutQuestion(QuestionInputModel questionmodel)
        {
            Mapper mapper = new Mapper();
            QuestionDTO questiondto = mapper.QuestionInputModelToQuestionDTO(questionmodel);
            AuthorDataAccess question = new AuthorDataAccess();
            question.UpdateQuestion(questiondto);            
        }

        [HttpDelete("question/{quid}/Author")]     //удаление вопроса из теста
        public int DeleteQuestionFromTest(int quid)
        {
            AuthorDataAccess question = new AuthorDataAccess();
            question.DeleteQuestionFromTest(quid);
            return quid;
        }

        [HttpPost("question/{quid}/answer/Author")]       //создать ответ для вопроса
        public int PostAnswer(AnswerInputModel answermodel)
        {
            Mapper mapper = new Mapper();
            AnswerDTO answerdto = mapper.AnswerInputModelToAnswerDTO(answermodel);
            AuthorDataAccess answer = new AuthorDataAccess();
            return answer.AddAnswer(answerdto);            
        }

        //[HttpGet("{testid}/question/{quid}/answers/Author")]       //список ответов на конкретный вопрос
        //public List<AnswerOutputModel> GetAnswerByQuestionId(int quid)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess answers = new AuthorDataAccess();
        //    return mapper.AnswerDTOToAnswerModelList(answers.GetAnswerByQuestionId(quid));            
        //}

        [HttpPut("answer/{anid}/Author")]     //редактировать ответ
        public void PutAnswer(AnswerInputModel answermodel)
        {
            Mapper mapper = new Mapper();
            AnswerDTO answerdto = mapper.AnswerInputModelToAnswerDTO(answermodel);
            AuthorDataAccess answer = new AuthorDataAccess();
            answer.UpdateAnswer(answerdto);            
        }

        [HttpDelete("answer/{anid}/Author")]   //удалить ответ
        public void DeleteAnswer(int anid)
        {
            AuthorDataAccess answer = new AuthorDataAccess();
            answer.DeleteAnswer(anid);
        }        
    }
}