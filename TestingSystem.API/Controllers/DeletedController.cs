using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestingSystem.Data;

namespace TestingSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeletedController : Controller
    {
        private readonly ILogger<DeletedController> _logger;

        public DeletedController(ILogger<DeletedController> logger)
        {
            _logger = logger;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Users")]
        public IActionResult GetDeletedUsers()
        {
            AdminDataAccess admin = new AdminDataAccess();
            UserMapper mapper = new UserMapper();
            return Ok(mapper.ConvertListUserDTOToListUserOutputModel(admin.GetDeletedUsers()));
        }
        [Authorize(Roles = "Admin,Author")]
        [HttpGet("Tests")]
        public IActionResult GetDeletedTests()
        {
            AdminDataAccess admin = new AdminDataAccess();
            Mapper mapper = new Mapper();
            return Ok(mapper.ConvertTestQuestionTagDTOToTestOutputListModel(admin.GetDeletedTests()));
        }
        [Authorize(Roles = "Admin,Author")]
        [HttpGet("Questions")]
        public IActionResult GetDeletedQuestions()
        {
            AdminDataAccess admin = new AdminDataAccess();
            Mapper mapper = new Mapper();
            return Ok(mapper.ConvertQuestionDTOToQuestionModelList(admin.GetDeletedQuestions()));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Groups")]
        public IActionResult GetDeletedGroups()
        {
            AdminDataAccess admin = new AdminDataAccess();
            Mapper mapper = new Mapper();
            return Ok(mapper.ConvertGroupWithStudentsAndTeachersDTOToGroupOutputModel(admin.GetDeletedGroups()));
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("User/{id}")]
        public IActionResult RestoreUser(int id)
        {
            AdminDataAccess access = new AdminDataAccess();
            var users = access.GetDeletedUsers();
            if (!users.Any(x => x.ID == id)) return BadRequest("Восстановление юзера по данному id невозможно ");

            AdminDataAccess admin = new AdminDataAccess();
            return Ok(admin.RestoreUser(id));
        }
        [Authorize(Roles = "Admin,Author")]
        [HttpPut("Test/{id}")]
        public IActionResult RestoreTest(int id)
        {
            AdminDataAccess access = new AdminDataAccess();
            var tests = access.GetDeletedTests();
            if (!tests.Any(x => x.ID == id)) return BadRequest("Восстановление теста по данному id невозможно");
            AdminDataAccess admin = new AdminDataAccess();
            return Ok(admin.RestoreTest(id));
        }
        [Authorize(Roles = "Admin,Author")]
        [HttpPut("Question/{id}")]
        public IActionResult RestoreQuestion(int id)
        {
            AdminDataAccess access = new AdminDataAccess();
            var questions = access.GetDeletedQuestions();
            if (!questions.Any(x => x.ID == id)) return BadRequest("Восстановление вопроса по данному id невозможно");
            AdminDataAccess admin = new AdminDataAccess();
            return Ok(admin.RestoreQuestion(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("Group/{id}")]
        public IActionResult RestoreGroup(int id)
        {
            AdminDataAccess access = new AdminDataAccess();
            var groups = access.GetDeletedGroups();
            if (!groups.Any(x => x.Id == id)) return BadRequest("Восстановление группы по данному id невозможно ");
            AdminDataAccess admin = new AdminDataAccess();
            return Ok(admin.RestoreGroup(id));
        }
    }
}
