using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestingSystem.Data;
using TestingSystem.Data.DTO;

namespace TestingSystem.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ILogger<TestsController> _logger;

        public TestsController(ILogger<TestsController> logger)
        {
            _logger = logger;
        }


        [HttpGet("Author/Tests")]  //вывод списка тестов

        public List<TestDTO> GetAllTest() 
        {
            AuthorDataAccess at =new AuthorDataAccess();
            return at.GetAllTest();       
        }

        [HttpPost("Author/Tests/AddTest")]  //создание теста

        public int AddTest(TestDTO test)
        {
            AuthorDataAccess at = new AuthorDataAccess();
            return at.AddTest(test);
        }

        [HttpGet("Author/Tests/SearchTestByTag")]  //поиск теста по тегу

        public List<SearchTestByTagDTO> GetTestVSTagSearch(params string[] tag) // добавить метод вывода по нескольким тегам одновременно
        {
            AuthorDataAccess tt = new AuthorDataAccess();
            return tt.GetTestVSTagSearchOr(tag);
        }

        [HttpGet("Author/Tests/id")]  //вывод информации о конкретном тесте

        public TestDTO GetByIdTest(int id) 
        {
            AuthorDataAccess ti = new AuthorDataAccess();
            return ti.GetByIdTest(id);
        }

        [HttpPut("Author/Tests/id")]  //изменение информации о конкретном тесте
       
        public int UpdateTestById(TestDTO test) 
        {
            AuthorDataAccess ut = new AuthorDataAccess();
            return ut.UpdateTest(test);
        }

        [HttpDelete("Author/Tests/id")]  //удаление конкретного тесте

        public int DeleteTestById(int id) 
        {
            AuthorDataAccess dt = new AuthorDataAccess();
            return dt.DeleteTest(id);
        }

        [HttpGet("Author/Tests/id/Questions")]  //вывод всех вопросов из конкретного теста

        public List<QuestionDTO> GetQuestionsByTestID(int testId)
        {
            AuthorDataAccess qt =new AuthorDataAccess();
            return qt.GetQuestionsByTestID(testId);
        }

        [HttpGet("Author/Tests/id/Tags")]  //вывод всех тегов конкретного теста

        public List<TagDTO> GetTagsInTest(TestDTO tests) 
        {
            AuthorDataAccess tt = new AuthorDataAccess();
            return tt.GetTagsInTest(tests);
        }

        [HttpPost("Author/Tests/id/Tags/id")] //добавление тега к конкретному тесту

        public int TestTagCreate(TestTagDTO testtag) 
        {
            AuthorDataAccess tt = new AuthorDataAccess();
            return tt.TestTagCreate(testtag);
        }

        [HttpDelete("Author/Tests/id/Tags/id")] //удаление тега из конкретного теста

        public void DeleteByTestIdTagId(int testId, int tagId)
        {
            AuthorDataAccess tt = new AuthorDataAccess();
            tt.DeleteByTestIdTagId(testId, tagId);
        }

        [HttpGet("Author/Tests/Tags")]  //вывод списка тегов

        public List<TagDTO> GetAllTag()
        {
            AuthorDataAccess tg = new AuthorDataAccess();
            return tg.GetAllTag();
        }

        [HttpPost("Author/Tests/Tags/AddTag")] //создание тега

        public int AddTag(TagDTO tag)
        {
            AuthorDataAccess at = new AuthorDataAccess();
            return at.AddTag(tag);
        }


        [HttpPut("Author/Tests/Tags/id")] //изменение конкретного тега

        public void UpdateTag(TagDTO tag) 
        {
            AuthorDataAccess ut = new AuthorDataAccess();
            ut.UpdateTag(tag);
        }

        [HttpDelete("Author/Tests/Tags/id")] //удаление конкретного тега

        public void DeleteTag(int id) 
        {
            AuthorDataAccess dt = new AuthorDataAccess();
            dt.DeleteTag(id);
        }



        [HttpPost("Author/Tests/id/Questionid/")]

        public int AddQuestion(QuestionDTO question)
        {
            AuthorDataAccess aq = new AuthorDataAccess();
            return aq.AddQuestion(question);
        }

        [HttpPost("Author/Tests/id/Questionid/Answer")]

        public int AddAnswer(AnswerDTO answer)
        {
            AuthorDataAccess aa = new AuthorDataAccess();
            return aa.AddAnswer(answer);
        }

        [HttpPut("Author/Tests/id/Questionid")]

        public void UpdateQuestion(QuestionDTO question)
        {
            AuthorDataAccess uq = new AuthorDataAccess();
            uq.UpdateQuestion(question);
        }

        [HttpPut("Author/Tests/id/Questionid/Answer")]

        public void UpdateAnswer(AnswerDTO answer)
        {
            AuthorDataAccess ua = new AuthorDataAccess();
            ua.UpdateAnswer(answer);
        }

        [HttpGet("Author/Tests/id/Questionid")]

        public QuestionDTO GetQuestionById(int id)
        {
            AuthorDataAccess gq = new AuthorDataAccess();
            return gq.GetQuestionById(id);
        }

        [HttpGet("Author/Tests/id/Questionid/Answer")]

        public List<AnswerDTO> GetAnswerByQuestionId(int questonId)
        {
            AuthorDataAccess ga = new AuthorDataAccess();
            return ga.GetAnswerByQuestionId(questonId);
        }

        [HttpDelete("Author/Tests/id/Questionid")]

        public int DeleteQuestionFromTest(int questionId)
        {
            AuthorDataAccess dq = new AuthorDataAccess();
            dq.DeleteQuestionFromTest(questionId);
            return questionId;
        }

        [HttpDelete("Author/Tests/id/Questionid/Answer")]

        public void DeleteAnswer(int id)
        {
            AuthorDataAccess da = new AuthorDataAccess();
            da.DeleteAnswer(id);
        }
    }
}