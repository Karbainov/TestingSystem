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
using TestingSystem.Business.Models;
using TestingSystem.Business;
using TestingSystem.Business.Attempt;


namespace TestingSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        
        //Запросы на основной странице "Tests" (список тестов/список тэгов)
        
        [HttpGet("Author")]    //вывод списка всех тестов
        public IActionResult GetAllTest()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tests = new AuthorDataAccess();
            return Json(mapper.ConvertTestDTOToTestModelList(tests.GetAllTest()));
        }

        [HttpGet("search-test-by-tags/Author")]    //поиск теста по тегу 
        public IActionResult GetTestVSTagSearch([FromBody] SearchTestByTagInputModel sttim)
        {            
            bool caseSwitch =sttim.SwitchValue;
            Mapper mapper = new Mapper();
            AuthorDataAccess search = new AuthorDataAccess();
            FindBy4AndMoreTags searchBy4AndMoreTags = new FindBy4AndMoreTags();
            StringConverter converter = new StringConverter();

            if (caseSwitch)

            {

                if (converter.CreateArrayFromString(sttim.Tag).Length < 3)

                {

                    return Json(mapper.ConvertTestDTOToTestModelList(search.GetTestVSTagSearchAnd(converter.CreateArrayFromString(sttim.Tag))));

                }

                else

                {

                    return Json(mapper.ConvertTestDTOToTestModelList(searchBy4AndMoreTags.FindAnd(sttim.Tag)));

                }

            }
            else

            {

                if (converter.CreateArrayFromString(sttim.Tag).Length < 3)

                {

                    return Json(mapper.ConvertTestDTOToTestModelList(search.GetTestVSTagSearchOr(converter.CreateArrayFromString(sttim.Tag))));

                }

                else

                {

                    return  Json(mapper.ConvertTestDTOToTestModelList(searchBy4AndMoreTags.FindOr(sttim.Tag)));

                }

            }
        }        

        [HttpGet("tags/Author")]      //cписок всех тегов
        public IActionResult GetAllTags()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tags = new AuthorDataAccess();
            return Json(mapper.ConvertTagDTOToTagModelList(tags.GetAllTag()));
        }

        [HttpPost("tag/Author")]      //создание тега
        public IActionResult PostTag([FromBody]TagInputModel tagmodel)           //спросить у Макса
        {
            if(string.IsNullOrWhiteSpace(tagmodel.Name))
                return BadRequest("Введите название тега");
            Mapper mapper = new Mapper();
            TagDTO tagdto = mapper.ConvertTagInputModelToTagDTO(tagmodel);
            AuthorDataAccess tag = new AuthorDataAccess();            
            return Ok(tag.AddTag(tagdto));
        }          

        [HttpPut("tag/Author")]      //изменение конкретного тега
        public IActionResult PutTag([FromBody]TagInputModel tagmodel)
        {
            if (string.IsNullOrWhiteSpace(tagmodel.Name))
                return BadRequest("Введите название тега");
            Mapper mapper = new Mapper();
            TagDTO tagdto = mapper.ConvertTagInputModelToTagDTO(tagmodel);
            AuthorDataAccess tag = new AuthorDataAccess();
            tag.UpdateTag(tagdto);            
            return Ok(tagmodel.ID);
        }

        [HttpDelete("tag/{tagId}/Author")]    //удаление конкретного тега
        public IActionResult DeleteTag(int tagId)
        {
            AuthorDataAccess tag = new AuthorDataAccess();
            tag.DeleteTag(tagId);
            return Ok(tagId);
        }



        //Запросы на странице конкретного теста "Id" (тест с информацией, вопросы, ответы теста)

        [HttpPost("Author")]       //создание теста
        public IActionResult PostTest(TestInputModel testmodel)
        {
            if (string.IsNullOrWhiteSpace(testmodel.Name))
                return BadRequest("Введите название теста");
            if (string.IsNullOrWhiteSpace(testmodel.DurationTime))
                return BadRequest("Введите время прохождения теста");
            if (testmodel.SuccessScore.HasValue)
                return BadRequest("Введите минимальный балл для прохождения теста");
            if (testmodel.QuestionNumber.HasValue)
                return BadRequest("Введите количество вопросов в тесте");
            Mapper mapper = new Mapper();
            TestDTO testdto = mapper.ConvertTestInputModelToTestDTO(testmodel);
            AuthorDataAccess test = new AuthorDataAccess();
            return Ok(test.AddTest(testdto));                    
        }

        [HttpPut("{testId}/Author")]        //изменение информации о конкретном тесте
        public IActionResult PutTestById([FromBody]TestInputModel testmodel)
        {
            if (string.IsNullOrWhiteSpace(testmodel.Name))
                return BadRequest("Введите название теста");
            if (string.IsNullOrWhiteSpace(testmodel.DurationTime))
                return BadRequest("Введите время прохождения теста");
            if (testmodel.SuccessScore.HasValue)
                return BadRequest("Введите минимальный балл для прохождения теста");
            if (testmodel.QuestionNumber.HasValue)
                return BadRequest("Введите количество вопросов в тесте");
            Mapper mapper = new Mapper();
            TestDTO testdto = mapper.ConvertTestInputModelToTestDTO(testmodel);
            AuthorDataAccess test = new AuthorDataAccess();
            return Ok(test.UpdateTest(testdto));            
        }

        [HttpDelete("{testId}/Author")]       //удаление конкретного тесте
        public IActionResult DeleteTestById(int testId)
        {
            AuthorDataAccess test = new AuthorDataAccess();
            return Ok(test.DeleteTest(testId));
        }

        [HttpGet("{testId}/Author")]     //полная информация о тесте
        public IActionResult GetTestInfo(int testId) 
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess ada = new AuthorDataAccess();
            TestOutputModel model = mapper.ConvertTestDTOToTestOutputModel(ada.GetByIdTest(testId));
            model.Questions = mapper.ConvertQuestionDTOToQuestionModelList(ada.GetQuestionsByTestID(testId));
            model.Tags = mapper.ConvertTagDTOToTagModelList(ada.GetTagsInTest(testId));
            foreach(QuestionOutputModel qom in model.Questions)
            {
                qom.Answers = mapper.ConvertAnswerDTOToAnswerModelList(ada.GetAnswerByQuestionId(qom.ID));
            }
            return Json(model);
        }

        //[HttpGet("{testId}/test-info/Author")]          //вывод информации о конкретном тесте
        //public IActionResult GetByIdTest(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess test = new AuthorDataAccess();
        //    return Json(mapper.ConvertTestDTOToTestOutputModel(test.GetByIdTest(testId)));
        //}

        //[HttpGet("{testId}/questions/Author")]          //вывод всех вопросов из конкретного теста
        //public IActionResult GetQuestionsByTestID(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess questions = new AuthorDataAccess();
        //    return Json(mapper.ConvertQuestionDTOToQuestionModelList(questions.GetQuestionsByTestID(testId)));
        //}

        //[HttpGet("{testId}/answers/Author")]          //вывод всех ответов из конкретного теста
        //public IActionResult GetAnswersByTestID(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess answers = new AuthorDataAccess();
        //    return Json(mapper.ConvertAnswerDTOToAnswerModelList(answers.GetAllAnswersInTest(testId)));
        //}

        //[HttpGet("{testId}/tags/Author")]         //вывод всех тегов конкретного теста
        //public IActionResult GetTagsInTest(int testId)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess tags = new AuthorDataAccess();
        //    return Json(mapper.ConvertTagDTOToTagModelList(tags.GetTagsInTest(testId)));
        //}

        [HttpGet("{testid}/missing-tags/Author")]          //вывод тегов, которых нет в тесте, для добавления
        public IActionResult GetTagsWhichAreNotInTest(int testid)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tags = new AuthorDataAccess();
            return Json(mapper.ConvertTagDTOToTagModelList(tags.GetTagsWhichAreNotInTest(testid)));
        }

        [HttpDelete("{testid}/tag/{tagid}/Author")]     //удаление тэга из конкретного теста
        public IActionResult DeleteTagFromTest(int testid, int tagid)
        {
            AuthorDataAccess tag = new AuthorDataAccess();
            tag.DeleteByTestIdTagId(testid, tagid);
            return Ok("Успешно удалено!");
        }

        [HttpPost("{testId}/tag/{tagid}/Author")]      //добавление существующего тэга к конкретному тесту (создаем новую связь тест-тэг)
        public IActionResult PostTagInTest(TestTagInputModel testtagmodel)
        {
            Mapper mapper = new Mapper();
            TestTagDTO testtagdto = mapper.ConvertTestTagInputModelToTestTagDTO(testtagmodel);
            AuthorDataAccess tag = new AuthorDataAccess();
            return Ok(tag.TestTagCreate(testtagdto));
        }



        //Запросы на странице конкретного вопроса у теста "Id/QuestionId" (вопрос с полной информацией, ответы на этот вопрос)
        
        [HttpPost("{testid}/question/Author")]       // создание вопроса конкретного теста
        public IActionResult PostQuestion(QuestionInputModel questionmodel)
        {
            if(string.IsNullOrWhiteSpace(questionmodel.Value))
                return BadRequest("Введите вопрос");
            if (questionmodel.TypeID.HasValue)
                return BadRequest("Введите тип вопроса");
            if (questionmodel.AnswersCount.HasValue)
                return BadRequest("Введите количество ответов на вопрос");
            if (questionmodel.Weight.HasValue)
                return BadRequest("Введите вес вопроса");
            Mapper mapper = new Mapper();
            QuestionDTO questiondto = mapper.ConvertQuestionInputModelToQuestionDTO(questionmodel);
            AuthorDataAccess question = new AuthorDataAccess();
            return Ok(question.AddQuestion(questiondto));            
        }

        //[HttpGet("question/{quid}/Author")]       // вывод вопроса
        //public IActionResult GetQuestionById([FromBody] int quid)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess question = new AuthorDataAccess();
        //    return Json(mapper.ConvertQuestionDTOToQuestionOutputModel(question.GetQuestionById(quid)));
        //}

        [HttpPut("question/{quid}/Author")]      // изменение конкретного вопроса из теста
        public IActionResult PutQuestion(QuestionInputModel questionmodel)
        {
            if (string.IsNullOrWhiteSpace(questionmodel.Value))
                return BadRequest("Введите вопрос");
            if (questionmodel.TypeID.HasValue)
                return BadRequest("Введите тип вопроса");
            if (questionmodel.AnswersCount.HasValue)
                return BadRequest("Введите количество ответов на вопрос");
            if (questionmodel.Weight.HasValue)
                return BadRequest("Введите вес вопроса");
            Mapper mapper = new Mapper();
            QuestionDTO questiondto = mapper.ConvertQuestionInputModelToQuestionDTO(questionmodel);
            AuthorDataAccess question = new AuthorDataAccess();
            question.UpdateQuestion(questiondto);
            return Ok("Изменения сделаны успешно");            
        }

        [HttpDelete("question/{quid}/Author")]     //удаление вопроса из теста
        public IActionResult DeleteQuestionFromTest(int quid)
        {
            AuthorDataAccess question = new AuthorDataAccess();
            question.DeleteQuestionFromTest(quid);
            return Ok(quid);
        }

        [HttpPost("question/{quid}/answer/Author")]       //создать ответ для вопроса
        public IActionResult PostAnswer(AnswerInputModel answermodel)
        {
            if(string.IsNullOrWhiteSpace(answermodel.Value))
                return BadRequest("Введите ответ");
            if (answermodel.Correct.HasValue)
                return BadRequest("Введите корректный ответ или нет");
            Mapper mapper = new Mapper();
            AnswerDTO answerdto = mapper.ConvertAnswerInputModelToAnswerDTO(answermodel);
            AuthorDataAccess answer = new AuthorDataAccess();
            return Ok(answer.AddAnswer(answerdto));            
        }

        //[HttpGet("{testid}/question/{quid}/answers/Author")]       //список ответов на конкретный вопрос
        //public IActionResult GetAnswerByQuestionId(int quid)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess answers = new AuthorDataAccess();
        //    return Json(mapper.ConvertAnswerDTOToAnswerModelList(answers.GetAnswerByQuestionId(quid)));
        //}

        [HttpPut("answer/{anid}/Author")]     //редактировать ответ
        public IActionResult PutAnswer(AnswerInputModel answermodel)
        {
            if (string.IsNullOrWhiteSpace(answermodel.Value))
                return BadRequest("Введите ответ");
            if (answermodel.Correct.HasValue)
                return BadRequest("Введите корректный ответ или нет");
            Mapper mapper = new Mapper();
            AnswerDTO answerdto = mapper.ConvertAnswerInputModelToAnswerDTO(answermodel);
            AuthorDataAccess answer = new AuthorDataAccess();
            answer.UpdateAnswer(answerdto);
            return Ok("Успешно изменено!");            
        }

        [HttpDelete("answer/{anid}/Author")]   //удалить ответ
        public IActionResult DeleteAnswer(int anid)
        {
            AuthorDataAccess answer = new AuthorDataAccess();
            answer.DeleteAnswer(anid);
            return new OkResult();
        }



        [HttpGet("{testid}/{userId}/Student")]
        public IActionResult GetTestAttempt(int testId, int userdId)

        {

            AttemptCreator studentattempt = new AttemptCreator();

            var attempt = studentattempt.CreateAttempt(userdId, testId);



            return Json(new Mapper().AttemptBusinessModelToConcreteAttemptOutputModel(attempt, testId, userdId));

        }

        [HttpPut("attempt/answers")]
        public IActionResult PutTestAttemptAnswers([FromBody] ConcreteAttemptInputModel concreteAttempt)
        {
            Mapper mapper = new Mapper();
            AttemptSaver saver = new AttemptSaver();
            saver.CreateAttemptResult(mapper.ConvertConcreteAttemptInputModelToConcreteAttemptBusinessModel(concreteAttempt));
            return new OkResult();
        }
    }
}