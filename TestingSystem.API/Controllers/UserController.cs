using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure.CRUD;
using TestingSystem.Data;
using TestingSystem.API.Models.Input;
using TestingSystem.API.Models.Output;
using TestingSystem.Business;
using Microsoft.AspNetCore.Authorization;

namespace TestingSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllUsersWithRoles()
        {
            AdminDataAccess adm = new AdminDataAccess();
            List<UserPositionDTO> users = adm.GetUsersWithRoles();
            UserMapper mapper = new UserMapper();
            return Ok(mapper.ConvertUserPositionDTOsToUserWithRolesOutputModels(users));
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            UserWithRolesOutputModel user = new UserWithRolesOutputModel();
            UserPositionDTO getUser = adm.GetUserWithRolesByUserId(id);
            if (getUser == null) { return BadRequest("Такого пользователя не существует"); }
            else
            {
                user = mapper.ConvertUserPositionDTOToUserWithRolesOutputModel(getUser);
                return Ok(user);
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult PostUser([FromBody] UserInputModel user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName)) return BadRequest("Вы не написали имя");
            if (string.IsNullOrWhiteSpace(user.LastName)) return BadRequest("Вы не написали фамилию");
            if (string.IsNullOrWhiteSpace(user.Login)) return BadRequest("Введите логин");
            if (string.IsNullOrWhiteSpace(user.Password)) return BadRequest("Введите пароль");
            if (string.IsNullOrWhiteSpace(user.Email)) return BadRequest("Введите почту");
            if (string.IsNullOrWhiteSpace(user.Phone)) return BadRequest("Напишите номер телефона");
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            adm.UserCreate(mapper.ConvertUserInputModelToUserDTO(user));

            return Ok("Пользователь создан успешно");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult PutUserById([FromBody] UserInputModel user)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            int result = adm.UserUpdate(mapper.ConvertUserInputModelToUserDTO(user));
            if (result == 0)
            {
                return BadRequest("Такого пользователя не существует");
            }
            if (result == 1)
            {
                return Ok("Пользователь обновлён");
            }
            else
            {
                return BadRequest("Ошибка базы данных");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{userId}")]
        public IActionResult DeleteUserById(int userId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            var user = adm.GetUserByID(userId);
            if (user == null) return BadRequest("Пользователя не существует");
            adm.UserDelete(userId);
            return Ok("Пользователь удалён");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{userId}/test")]
        public IActionResult GetStudentTestsByUserId(int userId)
        {
            StudentDataAccess student = new StudentDataAccess();
            Mapper mapper = new Mapper();
            List<TestAttemptDTO> tests = student.GetCompleteTests(userId);
            tests.AddRange(student.GetIncompleteTests(userId));
            StudentOutputModel model = mapper.ConvertUserDTOTestAttemptDTOToStudentModel(student.GetUser(userId), mapper.ConvertTestAttemptDTOToTestAttemptModel(tests));
            return Ok(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{userId}/test/{testId}")]
        public IActionResult GetAttemptsByUserIdTestId(int userId, int testId)
        {
            StudentDataAccess student = new StudentDataAccess();
            Mapper mapper = new Mapper();
            UserIdTestIdDTO dTO = new UserIdTestIdDTO(userId, testId);
            List<AttemptResultOutputModel> model = mapper.ConvertAttemptDTOToAttemptModel(student.GetAttemptsByUserIdTestId(dTO));
            return Ok(model);
        }

        [Authorize(Roles = "Admin,Teacher,Student")]
        [HttpGet("test/attempt/{attemptId}")]
        public IActionResult GetQuestionAndAnswerByAttemptId(int attemptId)
        {
            AttemptCRUD attempt = new AttemptCRUD();
            if (!attempt.GetAll().Any(a => a.id == attemptId)) return BadRequest("Несуществующий номер попытки");
            TeacherDataAccess teacher = new TeacherDataAccess();
            Mapper mapper = new Mapper();
            List<QuestionAnswerOutputModel> model = mapper.ConvertQuestionAnswerDTOToQuestionAnswerModel(teacher.GetQuestionAndAnswerByAttempt(attemptId));
            return Ok(model);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet("role")]
        public IActionResult GetRole()
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            List<RoleDTO> roles = adm.GetRoles();
            List<RoleOutputModel> rolesOut = new List<RoleOutputModel>();
            foreach (RoleDTO r in roles)
            {
                rolesOut.Add(mapper.ConvertRoleDTOToRoleOutputModel(r));
            }

            return Ok(rolesOut);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet("role/{roleID}")]
        public IActionResult GetUsersByRoleID(int roleId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            List<UserOutputModel> allUsers = new List<UserOutputModel>();
            UserMapper mapper = new UserMapper();
            var role = adm.GetRoleByRoleId(roleId);
            if (role == null) return BadRequest("Такой роли не существует");
            foreach (UserDTO user in adm.GetUsersByRoleID(roleId))
            {
                allUsers.Add(mapper.ConvertUserDTOToUserOutputModel(user));
            }
            return Ok(allUsers);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("role")]
        public IActionResult PostRoleIdToUserId([FromBody] UserRoleInputModel userRole)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            var user = adm.GetUserByID(userRole.UserID);
            if (user == null) return BadRequest("Пользователя не существует");
            var role = adm.GetRoleByRoleId(userRole.RoleID);
            if (role == null) return BadRequest("Такой роли не существует");
            List<UserRoleDTO> roles = adm.GetRolesByUserId(userRole.UserID);
            UserRoleDTO rl = mapper.ConvertUserRoleInputModelToUserRoleDTO(userRole);
            if (roles.Contains(rl)) return Ok("Данная роль для пользователя уже создана");
            adm.UserRoleCreate(mapper.ConvertUserRoleInputModelToUserRoleDTO(userRole));
            return Ok("Роль пользователя создана");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{userId}/role/{roleId}")]
        public IActionResult DeleteRoleIdFromUserId(int userId, int roleId)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            var user = adm.GetUserByID(userId);
            if (user == null) return BadRequest("Пользователя не существует");
            List<UserRoleDTO> roles = adm.GetRolesByUserId(userId);
            if (!roles.Any(r => r.RoleID == roleId)) return BadRequest("Такой роли пользователя не существует");
            adm.UserRoleDelete(userId, roleId);
            return Ok("Роль пользователя удалена");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("group/{groupID}/tests")]
        public IActionResult GetTestByGroupId(int groupId)
        {
            TeacherDataAccess teacher = new TeacherDataAccess();
            Mapper mapper = new Mapper();
            List<TestDTO> tests = teacher.GetTestByGroupId(groupId);
            if (tests == null) return BadRequest("Группы не существет");
            return Ok(mapper.ConvertTestDTOToTestModelList(teacher.GetTestByGroupId(groupId)));

            //TestOutputModel model = mapper.ConvertTestDTOToTestOutputModel(teacher.GetTestByGroupId(tests));
            //return Json(model);
        }

        [Authorize(Roles = "Author,Teacher")]
        [HttpGet("test/{testId}")]
        public ActionResult <List<AllTestsByStudentIdOutputModel>> GetGetAllStudentsByTest(int testId)
        {
            TeacherDataAccess teacher = new TeacherDataAccess();
            Mapper mapper = new Mapper();
            if (testId == null) return BadRequest("Группы не существет");
            return Ok(mapper.ConvertAllStudentTestsDTOToAllTestsByStudentIdOutputModel(teacher.GetStudentsByTestId(testId)));
        }

    }
}