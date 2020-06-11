using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestingSystem.Data;
using TestingSystem.Data.DTO;

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

        //главная страница

        [HttpGet("Author")]  //вывод списка тестов

        public List<TestDTO> /*outputmodel*/ GetAllTest()
        {            
            AuthorDataAccess at = new AuthorDataAccess();
            return at.GetAllTest();
            /*вызываем мапинг, чтобы преобразовать DTO в OutputModel*/
        }


        [HttpGet("SearchTestByTag/Author")]  //поиск теста по тегу     URL надо как-то изменить?

        public List<SearchTestByTagDTO> GetTestVSTagSearch(params string[] tag) // добавить метод вывода по нескольким тегам одновременно
        {
            AuthorDataAccess tt = new AuthorDataAccess();
            return tt.GetTestVSTagSearchOr(tag);
        }



        //страница с конкретным тестом

        [HttpGet("{Testid}/Author")]  //вывод информации о конкретном тесте

        public TestDTO GetByIdTest(int id)
        {
            AuthorDataAccess ti = new AuthorDataAccess();
            return ti.GetByIdTest(id);
        }


        [HttpGet("{Testid}/Author")]  //вывод всех вопросов из конкретного теста

        public List<QuestionDTO> GetQuestionsByTestID([FromBody]int testId)
        {
            AuthorDataAccess qt = new AuthorDataAccess();
            return qt.GetQuestionsByTestID(testId);
        }


        [HttpGet("{Testid}/Author")]  //вывод всех тегов конкретного теста

        public List<TagDTO> GetTagsInTest([FromBody]TestDTO tests)
        {
            AuthorDataAccess tt = new AuthorDataAccess();
            return tt.GetTagsInTest(tests);
        }


        [HttpPost("{Testid}/Author")]  //создание теста

        public int PostTest(TestDTO test)
        {
            AuthorDataAccess at = new AuthorDataAccess();
            return at.AddTest(test);
        }


        [HttpPut("{Testid}/Author")]  //изменение информации о конкретном тесте

        public int PutTestById(TestDTO test)
        {
            AuthorDataAccess ut = new AuthorDataAccess();
            return ut.UpdateTest(test);
        }


        [HttpDelete("{Testid}/Author")]  //удаление конкретного тесте

        public int DeleteTestById(int id)
        {
            AuthorDataAccess dt = new AuthorDataAccess();
            return dt.DeleteTest(id);
        }  
        





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

        [HttpGet("Tags/Author")]  //вывод списка тегов

        public List<TagDTO> GetAllTag()
        {
            AuthorDataAccess tg = new AuthorDataAccess();
            return tg.GetAllTag();
        }

        [HttpPost("Tags/Author")] //создание тега

        public int PostTag(TagDTO tag)
        {
            AuthorDataAccess at = new AuthorDataAccess();
            return at.AddTag(tag);
        }


        [HttpPut("Tags/{Tagid}/Author")] //изменение конкретного тега

        public void UpdateTag(TagDTO tag) 
        {
            AuthorDataAccess ut = new AuthorDataAccess();
            ut.UpdateTag(tag);
        }

        [HttpDelete("Tags/{Tagid}/Author")] //удаление конкретного тега

        public void DeleteTag(int id) 
        {
            AuthorDataAccess dt = new AuthorDataAccess();
            dt.DeleteTag(id);
        }


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