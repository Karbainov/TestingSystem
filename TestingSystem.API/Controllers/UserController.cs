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
using TestingSystem.Business.Statistics;

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
        [HttpPost("withrole")]
        public IActionResult PostUserWithRole([FromBody] UserWithRoleInputModel user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName)) return BadRequest("Вы не написали имя");
            if (string.IsNullOrWhiteSpace(user.LastName)) return BadRequest("Вы не написали фамилию");
            if (string.IsNullOrWhiteSpace(user.Login)) return BadRequest("Введите логин");
            if (string.IsNullOrWhiteSpace(user.Password)) return BadRequest("Введите пароль");
            if (string.IsNullOrWhiteSpace(user.Email)) return BadRequest("Введите почту");
            if (string.IsNullOrWhiteSpace(user.Phone)) return BadRequest("Напишите номер телефона");
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            adm.AddUserWithRole(mapper.ConvertUserWithRoleInputModelToUserWithRoleDTO(user));

            return Ok("Пользователь создан успешно");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult PutUserById([FromBody] UserInputModel user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName)) return BadRequest("Вы не написали имя");
            if (string.IsNullOrWhiteSpace(user.LastName)) return BadRequest("Вы не написали фамилию");
            if (string.IsNullOrWhiteSpace(user.Login)) return BadRequest("Введите логин");
            if (string.IsNullOrWhiteSpace(user.Password)) return BadRequest("Введите пароль");
            if (string.IsNullOrWhiteSpace(user.Email)) return BadRequest("Введите почту");
            if (string.IsNullOrWhiteSpace(user.Phone)) return BadRequest("Напишите номер телефона");
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

        [Authorize(Roles = "Teacher, Student")]
        [HttpGet("{userId}/test/{testId}")]
        public IActionResult GetAttemptsByUserIdTestId(int userId, int testId)
        {
            StudentDataAccess student = new StudentDataAccess();
            Mapper mapper = new Mapper();
            UserIdTestIdDTO dTO = new UserIdTestIdDTO(userId, testId);
            List<AttemptResultOutputModel> model = mapper.ConvertAttemptDTOToAttemptModel(student.GetAttemptsByUserIdTestId(dTO));
            return Ok(model);
        }

        //[Authorize(Roles = "Admin")]
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
        
        //[Authorize(Roles = "Admin")]
        [HttpGet("{userId}/role")]
        public IActionResult GetRolesByUserId(int userId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            List<RoleOutputModel> allUsers = new List<RoleOutputModel>();
            UserMapper mapper = new UserMapper();
            var roles = adm.GetRoleByUserId(userId);
            if (roles == null) return BadRequest("У пользователя нет ролей");
            foreach (RoleDTO role in adm.GetRoleByUserId(userId))
            {
                allUsers.Add(mapper.ConvertRoleDTOToRoleOutputModel(role));
            }
            return Ok(allUsers);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet("role/{roleID}")]
        public IActionResult GetUsersByRoleId(int roleId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            List<UserOutputModel> allUsers = new List<UserOutputModel>();
            UserMapper mapper = new UserMapper();
            var role = adm.GetRoleByRoleId(roleId);
            if (role == null) return BadRequest("Указанной роли не существует");
            foreach (UserDTO user in adm.GetUsersByRoleId(roleId))
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

        [Authorize(Roles = "Teacher, Student")]
        [HttpGet("attempt/{AttemptID}")]
        public IActionResult GetQuestionAndAnswerByAttemptId(int attemptId)
        {
            TeacherDataAccess teacher = new TeacherDataAccess();
            Mapper mapper = new Mapper();
            List<QuestionAnswerDTO> answers = teacher.GetQuestionAndAnswerByAttempt(attemptId);
            if (answers == null) return BadRequest("Несуществующий номер попытки");
            return Ok (mapper.ConvertQuestionAnswerDTOToQuestionAnswerModel(teacher.GetQuestionAndAnswerByAttempt(attemptId)));
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
        }

        [Authorize(Roles = "Author,Teacher")]
        [HttpGet("test/{testId}")]
        public ActionResult<List<AllTestsByStudentIdOutputModel>> GetGetAllStudentsByTestId(int testId)
        {
            TeacherDataAccess teacher = new TeacherDataAccess();
            Mapper mapper = new Mapper();
            AuthorDataAccess tests = new AuthorDataAccess();
            var test = tests.GetTestById(testId);
            if (test == null) return BadRequest("Теста не существует");
            return Ok(mapper.ConvertAllStudentTestsDTOToAllTestsByStudentIdOutputModel(teacher.GetStudentsByTestId(testId)));
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("teacher/{userId}/{groupId}")]
        public IActionResult GetGroupTestsAndResults(int userId, int groupId)
        {
            TeacherDataAccess teacher = new TeacherDataAccess();
            Mapper mapper = new Mapper();
            TeacherGroup groups = new TeacherGroup();
            var g = groups.GetAll();
            if (!g.Any(g => g.UserID == userId)) return BadRequest("Такой преподаватель отсутствует");
            if (!g.Any(g => g.GroupID == groupId)) return BadRequest("Группа отсутствует");
            if (!groups.GetAllByUserId(userId).Any(g => g.GroupID == groupId)) return BadRequest("Группа относится к другому преподавателю");
            List<TestDTO> tests = teacher.GetTestByGroupId(groupId);
            GroupStatistics gs = new GroupStatistics(groupId);
            Dictionary<int, double> statistic = gs.GetAverageResultsOfAllTestsByGroupId(groupId);
            return Ok(mapper.ConvertTestDTOToGroupTestsAndResultsOutputModel(tests,statistic));
        }
        
    }
}