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

        [HttpGet("Author/Tests")]


        public List<TestDTO> GetAllTest() 
        {
            AuthorDataAccess at =new AuthorDataAccess();
            return at.GetAllTest();       
        }

        [HttpPost("Author/Tests/AddTest")]

        public int AddTest(TestDTO test)
        {
            AuthorDataAccess at = new AuthorDataAccess();
            return at.AddTest(test);
        }

        [HttpPost("Author/Tests/AddTest/AddTag")]

        public int AddTag(TagDTO tag)
        {
            AuthorDataAccess at = new AuthorDataAccess();
            return at.AddTag(tag);
        }


        [HttpPost("Author/Tests/SearchTestByTag")]

        public List<SearchTestByTagDTO> GetTestVSTagSearch(params string[] tag) // добавить метод вывода по нескольким тегам одновременно
        {
            AuthorDataAccess tt = new AuthorDataAccess();
            return tt.GetTestVSTagSearchOr(tag);     
        }



    }
}