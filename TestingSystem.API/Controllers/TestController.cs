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
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "Author,Teacher")]
        [HttpGet]    //вывод списка всех тестов
        public ActionResult <List<TestOutputModel>> GetAllTest()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tests = new AuthorDataAccess();
            return Ok(mapper.ConvertTestDTOToTestModelList(tests.GetAllTest()));
        }

        [Authorize(Roles = "Author,Teacher")]
        [HttpGet("search-test-by-tags")]    //поиск теста по тегу 
        public ActionResult <List<TestOutputModel>> GetTestVSTagSearch([FromBody] SearchTestByTagInputModel sttim)
        {            
            bool caseSwitch =sttim.SwitchValue;
            Mapper mapper = new Mapper();
            AuthorDataAccess search = new AuthorDataAccess();
            FindBy4AndMoreTags searchBy4AndMoreTags = new FindBy4AndMoreTags();
            StringConverter converter = new StringConverter();

            if (caseSwitch)            {                if (converter.CreateArrayFromString(sttim.Tag).Length < 3)                {                    return Ok(mapper.ConvertTestDTOToTestModelList(search.GetTestVSTagSearchAnd(converter.CreateArrayFromString(sttim.Tag))));                }                else                {                    return Ok(mapper.ConvertTestDTOToTestModelList(searchBy4AndMoreTags.FindAnd(sttim.Tag)));                }            }
            else            {                if (converter.CreateArrayFromString(sttim.Tag).Length < 3)                {                    return Ok(mapper.ConvertTestDTOToTestModelList(search.GetTestVSTagSearchOr(converter.CreateArrayFromString(sttim.Tag))));                }                else                {                    return  Ok(mapper.ConvertTestDTOToTestModelList(searchBy4AndMoreTags.FindOr(sttim.Tag)));                }            }
        }

        [Authorize(Roles = "Author,Teacher")]
        [HttpGet("tags")]      //cписок всех тегов
        public ActionResult <List<TagOutputModel>> GetAllTags()
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tags = new AuthorDataAccess();
            return Ok(mapper.ConvertTagDTOToTagModelList(tags.GetAllTag()));
        }

        [Authorize(Roles = "Author")]
        [HttpPost("tag")]      //создание тега
        public ActionResult <int> PostTag([FromBody]TagInputModel tagmodel)           //спросить у Макса
        {
            if(string.IsNullOrWhiteSpace(tagmodel.Name)) return BadRequest("Введите название тега");
            Mapper mapper = new Mapper();
            TagDTO tagdto = mapper.ConvertTagInputModelToTagDTO(tagmodel);
            AuthorDataAccess tag = new AuthorDataAccess();            
            return Ok(tag.AddTag(tagdto));
        }

        [Authorize(Roles = "Author")]
        [HttpPut("tag")]      //изменение конкретного тега
        public ActionResult<int> PutTag([FromBody]TagInputModel tagmodel)
        {
            Mapper mapper = new Mapper();
            TagDTO tagdto = mapper.ConvertTagInputModelToTagDTO(tagmodel);
            AuthorDataAccess tags = new AuthorDataAccess();
            var tag = tags.GetTagById(tagmodel.ID);
            if (tag == null) return BadRequest("Тега не существует");
            if (string.IsNullOrWhiteSpace(tagmodel.Name)) return BadRequest("Введите название тега");
            tags.UpdateTag(tagdto);            
            return Ok(tagmodel.ID);
        }

        [Authorize(Roles = "Author")]
        [HttpDelete("tag/{tagId}")]    //удаление конкретного тега
        public ActionResult<int> DeleteTag(int tagId)
        {
            AuthorDataAccess tags = new AuthorDataAccess();
            var tag = tags.GetTagById(tagId);
            if (tag == null) return BadRequest("Тега не существует");
            tags.DeleteTag(tagId);
            return Ok(tagId);
        }



        //Запросы на странице конкретного теста "Id" (тест с информацией, вопросы, ответы теста)

        [Authorize(Roles = "Author")]
        [HttpPost]       //создание теста                       ??? выдает 
        public ActionResult<int> PostTest(TestInputModel testmodel)
        {
            if (string.IsNullOrWhiteSpace(testmodel.Name)) return BadRequest("Введите название теста");
            if (string.IsNullOrWhiteSpace(testmodel.DurationTime)) return BadRequest("Введите время прохождения теста");
            if (testmodel.QuestionNumber ==null) return BadRequest("Введите количество вопросов в тесте");
            if (testmodel.SuccessScore == null) return BadRequest("Введите минимальный балл для прохождения теста");
            Mapper mapper = new Mapper();
            TestDTO testdto = mapper.ConvertTestInputModelToTestDTO(testmodel);
            AuthorDataAccess test = new AuthorDataAccess();
            return Ok(test.AddTest(testdto));                    
        }

        [Authorize(Roles = "Author")]
        [HttpPut]        //изменение информации о конкретном тесте
        public ActionResult<int> PutTestById([FromBody]TestInputModel testmodel)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tests = new AuthorDataAccess();
            if (string.IsNullOrWhiteSpace(testmodel.Name)) return BadRequest("Введите название теста");
            if (string.IsNullOrWhiteSpace(testmodel.DurationTime)) return BadRequest("Введите время прохождения теста");
            if (testmodel.QuestionNumber == null) return BadRequest("Введите количество вопросов в тесте");
            if (testmodel.SuccessScore == null) return BadRequest("Введите минимальный балл для прохождения теста");
            TestDTO testdto = mapper.ConvertTestInputModelToTestDTO(testmodel);
            return Ok(tests.UpdateTest(testdto));
        }

        [Authorize(Roles = "Author")]
        [HttpDelete("{testId}")]       //удаление конкретного тесте
        public ActionResult<int> DeleteTestById(int testId)
        {
            AuthorDataAccess tests = new AuthorDataAccess();
            var test = tests.GetByIdTest(testId);
            if (test == null) return BadRequest("Теста не существует");
            return Ok(tests.DeleteTest(testId));
        }

        [Authorize(Roles = "Author,Teacher")]
        [HttpGet("{testId}")]     //полная информация о тесте
        public IActionResult GetTestInfo(int testId) 
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess ada = new AuthorDataAccess();
            var test = ada.GetByIdTest(testId);
            if (test == null) return BadRequest("Теста не существует");
            TestOutputModel model = mapper.ConvertTestDTOToTestOutputModel(ada.GetByIdTest(testId));
            model.Questions = mapper.ConvertQuestionDTOToQuestionModelList(ada.GetQuestionsByTestID(testId));
            model.Tags = mapper.ConvertTagDTOToTagModelList(ada.GetTagsInTest(testId));
            foreach(QuestionOutputModel qom in model.Questions)
            {
                qom.Answers = mapper.ConvertAnswerDTOToAnswerModelList(ada.GetAnswerByQuestionId(qom.ID));
            }
            return Ok(model);
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

        [Authorize(Roles = "Author")]
        [HttpGet("{testid}/missing-tags")]          //вывод тегов, которых нет в тесте, для добавления
        public ActionResult<List<TagOutputModel>> GetTagsWhichAreNotInTest(int testId)
        {
            Mapper mapper = new Mapper();
            AuthorDataAccess tags = new AuthorDataAccess();
            var test = tags.GetByIdTest(testId);
            if (test == null) return BadRequest("Теста не существует");
            return Ok(mapper.ConvertTagDTOToTagModelList(tags.GetTagsWhichAreNotInTest(testId)));
        }

        [Authorize(Roles = "Author")]
        [HttpDelete("delete-tag-from-test")]     //удаление тэга из конкретного теста
        public ActionResult<int> DeleteTagFromTest(TestTagInputModel testtagmodel)
        {
            AuthorDataAccess tags = new AuthorDataAccess();
            var test = tags.GetByIdTest(testtagmodel.TestID);
            if (test == null) return BadRequest("Теста не существует");
            var tag = tags.GetTagById(testtagmodel.TagID);
            if (tag == null) return BadRequest("Тега не существует");
            var testTag = tags.GetTestByTag(testtagmodel.TestID, testtagmodel.TagID);
            if (testTag == null) return BadRequest("У данного теста нет такого тега");
            tags.DeleteByTestIdTagId(testtagmodel.TestID, testtagmodel.TagID);
            return Ok("Успешно удалено!");
        }

        [Authorize(Roles = "Author")]
        [HttpPost("post-tag-in-test")]      //добавление существующего тэга к конкретному тесту (создаем новую связь тест-тэг)
        public ActionResult<int> PostTagInTest(TestTagInputModel testtagmodel)
        {
            Mapper mapper = new Mapper();
            TestTagDTO testtagdto = mapper.ConvertTestTagInputModelToTestTagDTO(testtagmodel);
            AuthorDataAccess tags = new AuthorDataAccess();
            var test = tags.GetByIdTest(testtagmodel.TestID);
            if (test == null) return BadRequest("Теста не существует");
            var tag = tags.GetTagById(testtagmodel.TagID);
            if (tag == null) return BadRequest("Тега не существует");
            return Ok(tags.TestTagCreate(testtagdto));
        }

        //Запросы на странице конкретного вопроса у теста "Id/QuestionId" (вопрос с полной информацией, ответы на этот вопрос)

        [Authorize(Roles = "Author")]
        [HttpPost("add-question-by-test")]       // создание вопроса конкретного теста   ??????? не работает!!!
        public ActionResult<int> PostQuestion(QuestionInputModel questionmodel)
        {
            Mapper mapper = new Mapper();
            QuestionDTO questiondto = mapper.ConvertQuestionInputModelToQuestionDTO(questionmodel);
            AuthorDataAccess questions = new AuthorDataAccess();
            var test = questions.GetByIdTest(questionmodel.TestID);
            if (test == null) return BadRequest("Теста не существует");
            if (string.IsNullOrWhiteSpace(questionmodel.Value)) return BadRequest("Введите вопрос");
            if (questionmodel.TypeID == null) return BadRequest("Введите тип вопроса");
            if (questionmodel.AnswersCount == null) return BadRequest("Введите количество ответов на вопрос");
            if (questionmodel.Weight == null) return BadRequest("Введите вес вопроса");
            return Ok(questions.AddQuestion(questiondto));            
        }

        //[HttpGet("question/{quid}/Author")]       // вывод вопроса
        //public IActionResult GetQuestionById([FromBody] int quid)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess question = new AuthorDataAccess();
        //    return Json(mapper.ConvertQuestionDTOToQuestionOutputModel(question.GetQuestionById(quid)));
        //}

        [Authorize(Roles = "Author")]
        [HttpPut("question-update")]      // изменение конкретного вопроса из теста
        public ActionResult<int> PutQuestion(QuestionInputModel questionmodel)
        {
            Mapper mapper = new Mapper();
            QuestionDTO questiondto = mapper.ConvertQuestionInputModelToQuestionDTO(questionmodel);
            AuthorDataAccess questions = new AuthorDataAccess();
            var question = questions.GetQuestionById(questionmodel.ID);
            if (question == null) return BadRequest("Вопроса не существует");
            var test = questions.GetByIdTest(questionmodel.TestID);
            if (test == null) return BadRequest("Теста не существует");
            if (string.IsNullOrWhiteSpace(questionmodel.Value)) return BadRequest("Введите вопрос");
            if (questionmodel.TypeID ==null) return BadRequest("Введите тип вопроса");
            if (questionmodel.AnswersCount == null) return BadRequest("Введите количество ответов на вопрос");
            if (questionmodel.Weight == null) return BadRequest("Введите вес вопроса");          
            questions.UpdateQuestion(questiondto);
            return Ok("Изменения сделаны успешно");            
        }

        [Authorize(Roles = "Author")]
        [HttpDelete("question-delete/{quid}")]     //удаление вопроса из теста
        public ActionResult<int> DeleteQuestionFromTest(int quid)
        {
            AuthorDataAccess questions = new AuthorDataAccess();
            var question = questions.GetQuestionById(quid);
            if (question == null) return BadRequest("Вопроса не существует");
            questions.DeleteQuestionFromTest(quid);
            return Ok(quid);
        }

        [Authorize(Roles = "Author")]
        [HttpPost("answer")]       //создать ответ для вопроса
        public ActionResult<int> PostAnswer(AnswerInputModel answermodel)
        {
            Mapper mapper = new Mapper();
            AnswerDTO answerdto = mapper.ConvertAnswerInputModelToAnswerDTO(answermodel);
            AuthorDataAccess answer = new AuthorDataAccess();
            var question = answer.GetQuestionById(answermodel.QuestionID);
            if (question == null) return BadRequest("Вопроса не существует");
            if (string.IsNullOrWhiteSpace(answermodel.Value)) return BadRequest("Введите ответ");
            if (answermodel.Correct==null) return BadRequest("Введите корректный ответ или нет");          
            return Ok(answer.AddAnswer(answerdto));            
        }

        //[HttpGet("{testid}/question/{quid}/answers/Author")]       //список ответов на конкретный вопрос
        //public IActionResult GetAnswerByQuestionId(int quid)
        //{
        //    Mapper mapper = new Mapper();
        //    AuthorDataAccess answers = new AuthorDataAccess();
        //    return Json(mapper.ConvertAnswerDTOToAnswerModelList(answers.GetAnswerByQuestionId(quid)));
        //}

        [Authorize(Roles = "Author")]
        [HttpPut("answer-update")]     //редактировать ответ
        public ActionResult PutAnswer(AnswerInputModel answermodel)
        {
            Mapper mapper = new Mapper();
            AnswerDTO answerdto = mapper.ConvertAnswerInputModelToAnswerDTO(answermodel);
            AuthorDataAccess answers = new AuthorDataAccess();
            var answer = answers.GetAnswerById(answermodel.ID);
            if (answer == null) return BadRequest("Ответа не существует");
            var question = answers.GetQuestionById(answermodel.QuestionID);
            if (question == null) return BadRequest("Вопроса не существует");
            if (string.IsNullOrWhiteSpace(answermodel.Value)) return BadRequest("Введите ответ");
            if (answermodel.Correct==null) return BadRequest("Введите корректный ответ или нет");
            answers.UpdateAnswer(answerdto);
            return Ok("Успешно изменено!");            
        }

        [Authorize(Roles = "Author")]
        [HttpDelete("answer/{anid}")]   //удалить ответ
        public ActionResult<int> DeleteAnswer(int anid)
        {
            AuthorDataAccess answers = new AuthorDataAccess();
            var answer = answers.GetAnswerById(anid);
            if (answer == null) return BadRequest("Ответа не существует");
            answers.DeleteAnswer(anid);
            return Ok(anid);
        }
        [Authorize(Roles = "Author,Teacher,Student")]
        [HttpGet("{testid}/{userId}")]

        public IActionResult GetTestAttempt(int testId, int userdId)
        {
            AttemptCreator studentattempt = new AttemptCreator();
            var attempt = studentattempt.CreateAttempt(userdId, testId);

            return Json(new Mapper().AttemptBusinessModelToConcreateAttemptOutputModel(attempt, testId, userdId));
        }
    }
}