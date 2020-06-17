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
        public IActionResult GetAllTags()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tags = new AuthorDataAccess();
            return Json(mapper.TagDTOToTagModelList(tags.GetAllTag()));
        }

        [HttpPost("tag/Author")]      //создание тега
        public IActionResult PostTag([FromBody]TagInputModel tagmodel)           //спросить у Макса
        {
            if(tagmodel.Name != "")
            {
                Mapper mapper = new Mapper();
                TagDTO tagdto = mapper.TagInputModelToTagDTO(tagmodel);
                AuthorDataAccess tag = new AuthorDataAccess();
                return Json(tag.AddTag(tagdto));
            }
            else
            {
                return new BadRequestResult();
            }
            
        }

        [HttpPut("tag/Author")]      //изменение конкретного тега
        public IActionResult PutTag([FromBody]TagInputModel tagmodel)
        {
            if (tagmodel.Name != "")
            {
                Mapper mapper = new Mapper();
                TagDTO tagdto = mapper.TagInputModelToTagDTO(tagmodel);
                AuthorDataAccess tag = new AuthorDataAccess();
                tag.UpdateTag(tagdto);
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
            
        }

        [HttpDelete("tag/{tagId}/Author")]    //удаление конкретного тега
        public IActionResult DeleteTag(int tagId)
        {
            AuthorDataAccess tag = new AuthorDataAccess();
            tag.DeleteTag(tagId);
            return Json("Не знаю, что выводить");
        }



        //Запросы на странице конкретного теста "Id" (тест с информацией, вопросы, ответы теста)

        [HttpPost("Author")]       //создание теста
        public IActionResult PostTest(TestInputModel testmodel)
        {            
            Mapper mapper = new Mapper();
            TestDTO testdto = mapper.TestInputModelToTestDTO(testmodel);
            AuthorDataAccess test = new AuthorDataAccess();
            return Json(test.AddTest(testdto));            
        }

        [HttpPut("{testId}/Author")]        //изменение информации о конкретном тесте
        public IActionResult PutTestById([FromBody]TestInputModel testmodel)
        {
            Mapper mapper = new Mapper();
            TestDTO testdto = mapper.TestInputModelToTestDTO(testmodel);
            AuthorDataAccess test = new AuthorDataAccess();
            return Json(test.UpdateTest(testdto));            
        }

        [HttpDelete("{testId}/Author")]       //удаление конкретного тесте
        public IActionResult DeleteTestById(int testId)
        {
            AuthorDataAccess test = new AuthorDataAccess();
            return Json(test.DeleteTest(testId));
        }

        [HttpGet("{testId}/Author")]     //полная информация о тесте
        public IActionResult GetTestInfo(int testId) 
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
            return Json(model);
        }

        //[HttpGet("{testId}/test-info/Author")]          //вывод информации о конкретном тесте
        //public IActionResult GetByIdTest(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess test = new AuthorDataAccess();
        //    return Json(mapper.TestDTOToTestOutputModel(test.GetByIdTest(testId)));            
        //}

        //[HttpGet("{testId}/questions/Author")]          //вывод всех вопросов из конкретного теста
        //public IActionResult GetQuestionsByTestID(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess questions = new AuthorDataAccess();
        //    return Json(mapper.QuestionDTOToQuestionModelList(questions.GetQuestionsByTestID(testId)));            
        //}

        //[HttpGet("{testId}/answers/Author")]          //вывод всех ответов из конкретного теста
        //public IActionResult GetAnswersByTestID(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess answers = new AuthorDataAccess();
        //    return Json(mapper.AnswerDTOToAnswerModelList(answers.GetAllAnswersInTest(testId)));
        //}

        //[HttpGet("{testId}/tags/Author")]         //вывод всех тегов конкретного теста
        //public IActionResult GetTagsInTest(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess tags = new AuthorDataAccess();            
        //    return Json(mapper.TagDTOToTagModelList(tags.GetTagsInTest(testId)));            
        //}

        [HttpGet("{testid}/missing-tags/Author")]          //вывод тегов, которых нет в тесте, для добавления
        public IActionResult GetTagsWhichAreNotInTest(int testid)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tags = new AuthorDataAccess();
            return Json(mapper.TagDTOToTagModelList(tags.GetTagsWhichAreNotInTest(testid)));
        }

        [HttpDelete("{testid}/tag/{tagid}/Author")]     //удаление тэга из конкретного теста
        public IActionResult DeleteTagFromTest(int testid, int tagid)
        {
            AuthorDataAccess tag = new AuthorDataAccess();
            tag.DeleteByTestIdTagId(testid, tagid);
            return Json("Не знаю, что выводить");
        }

        [HttpPost("{testId}/tag/{tagid}/Author")]      //добавление существующего тэга к конкретному тесту (создаем новую связь тест-тэг)
        public IActionResult PostTagInTest(TestTagInputModel testtagmodel)
        {
            Mapper mapper = new Mapper();
            TestTagDTO testtagdto = mapper.TestTagInputModelToTestTagDTO(testtagmodel);
            AuthorDataAccess tag = new AuthorDataAccess();
            return Json(tag.TestTagCreate(testtagdto));
        }



        //Запросы на странице конкретного вопроса у теста "Id/QuestionId" (вопрос с полной информацией, ответы на этот вопрос)
        
        [HttpPost("{testid}/question/Author")]       // создание вопроса конкретного теста
        public IActionResult PostQuestion(QuestionInputModel questionmodel)
        {
            Mapper mapper = new Mapper();
            QuestionDTO questiondto = mapper.QuestionInputModelToQuestionDTO(questionmodel);
            AuthorDataAccess question = new AuthorDataAccess();
            return Json(question.AddQuestion(questiondto));            
        }

        //[HttpGet("{testid}/question/{quid}/Author")]       // вывод вопроса
        //public IActionResult GetQuestionById([FromBody] int quid)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess question = new AuthorDataAccess();
        //    return Json(mapper.QuestionDTOToQuestionOutputModel(question.GetQuestionById(quid)));            
        //}

        [HttpPut("question/{quid}/Author")]      // изменение конкретного вопроса из теста
        public IActionResult PutQuestion(QuestionInputModel questionmodel)
        {
            Mapper mapper = new Mapper();
            QuestionDTO questiondto = mapper.QuestionInputModelToQuestionDTO(questionmodel);
            AuthorDataAccess question = new AuthorDataAccess();
            question.UpdateQuestion(questiondto);
            return Json("Не знаю, что выводить");
        }

        [HttpDelete("question/{quid}/Author")]     //удаление вопроса из теста
        public IActionResult DeleteQuestionFromTest(int quid)
        {
            AuthorDataAccess question = new AuthorDataAccess();
            question.DeleteQuestionFromTest(quid);
            return Json(quid);
        }

        [HttpPost("question/{quid}/answer/Author")]       //создать ответ для вопроса
        public IActionResult PostAnswer(AnswerInputModel answermodel)
        {
            Mapper mapper = new Mapper();
            AnswerDTO answerdto = mapper.AnswerInputModelToAnswerDTO(answermodel);
            AuthorDataAccess answer = new AuthorDataAccess();
            return Json(answer.AddAnswer(answerdto));            
        }

        //[HttpGet("{testid}/question/{quid}/answers/Author")]       //список ответов на конкретный вопрос
        //public IActionResult GetAnswerByQuestionId(int quid)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess answers = new AuthorDataAccess();
        //    return Json(mapper.AnswerDTOToAnswerModelList(answers.GetAnswerByQuestionId(quid)));            
        //}

        [HttpPut("answer/{anid}/Author")]     //редактировать ответ
        public IActionResult PutAnswer(AnswerInputModel answermodel)
        {
            Mapper mapper = new Mapper();
            AnswerDTO answerdto = mapper.AnswerInputModelToAnswerDTO(answermodel);
            AuthorDataAccess answer = new AuthorDataAccess();
            answer.UpdateAnswer(answerdto);
            return Json("Не знаю, что выводить");
        }

        [HttpDelete("answer/{anid}/Author")]   //удалить ответ
        public IActionResult DeleteAnswer(int anid)
        {
            AuthorDataAccess answer = new AuthorDataAccess();
            answer.DeleteAnswer(anid);
            return Json("Не знаю, что выводить");
        }        
    }
}