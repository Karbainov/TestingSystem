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
using Newtonsoft.Json.Serialization;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using TestingSystem.API.Shared;

namespace TestingSystem.API.Controllers
{
        [ApiController]
        [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<GroupController> _logger;

        public UserController(ILogger<GroupController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] UserInputModel user)
        {
            if(string.IsNullOrWhiteSpace(user.FirstName)) return BadRequest("Вы не написали имя");
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
        
        [HttpPost("role")]
        public IActionResult PostUserRole([FromBody] UserRoleInputModel userRole)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            var user = adm.GetUserByID(userRole.UserID);
            if (user == null) return BadRequest("Пользователя не существует");
            var role = adm.GetRoleByRoleID(userRole.RoleID);
            if (role == null) return BadRequest("Такой роли не существует");
            List<UserRoleDTO> roles = adm.GetRolesByUserId(userRole.UserID);
            UserRoleDTO rl = mapper.ConvertUserRoleInputModelToUserRoleDTO(userRole);
            if (roles.Contains(rl)) return Ok("Данная роль для пользователя уже создана");
            adm.UserRoleCreate(mapper.ConvertUserRoleInputModelToUserRoleDTO(userRole));
            return Ok("Роль пользователя создана");
        }
        
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

            return Json(rolesOut);
        }
        
        [HttpGet("{userId}/role")]
        public IActionResult GetRoleByUserId(int userId)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            var user = adm.GetUserByID(userId);
            if (user == null) return BadRequest("Пользователя не существует");
            List<RoleDTO> roles = adm.GetRoleByUserId(userId);
            if (roles == null) return Ok("У пользователя нет роли");
            List<RoleOutputModel> rolesOut = new List<RoleOutputModel>();
            foreach (RoleDTO r in roles)
                {
                    rolesOut.Add(mapper.ConvertRoleDTOToRoleOutputModel(r));
                }
                return Json(rolesOut);
        }
        
        [HttpGet]
        public IActionResult GetAllUsersWithRoles()
        {
            AdminDataAccess adm = new AdminDataAccess();
            List<UserPositionDTO> users = adm.GetAllUsersWithRoles();
            UserMapper mapper = new UserMapper();
            return Json(mapper.ConvertUserPositionDTOsToUserWithRolesOutputModels(users));
        }
        
        
        [HttpGet("role/{roleID}")]
        public IActionResult GetUsersByRoleID(int roleID)
        {
            AdminDataAccess adm = new AdminDataAccess();
            List<UserOutputModel> allUsers = new List<UserOutputModel>();
            UserMapper mapper = new UserMapper();
            var role = adm.GetRoleByRoleID(roleID);
            if (role == null) return BadRequest("Такой роли не существует");
            foreach (UserDTO user in adm.GetUsersByRoleID(roleID))
            {
                allUsers.Add(mapper.ConvertUserDTOToUserOutputModel(user));
            }
            return Json(allUsers);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            UserOutputModel user = new UserOutputModel();
            UserDTO getUser = adm.GetUserByID(id);
            if (getUser == null) { return new BadRequestObjectResult("Такого пользователя не существует"); }
            else {
                user = mapper.ConvertUserDTOToUserOutputModel(getUser);
                return Json(user); 
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] UserInputModel user)
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
        
        [HttpDelete("{userId}/role/{roleId}")]
        public IActionResult DeleteUserRole(int userId, int roleId)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            var user = adm.GetUserByID(userId);
            if (user == null) return BadRequest("Пользователя не существует");
            List<UserRoleDTO> roles = adm.GetRolesByUserId(userId);
            if (!roles.Any(a=> a.RoleID ==roleId )) return BadRequest("Такой роли пользователя не существует");
            adm.UserRoleDelete(userId, roleId);
            return Ok("Роль пользователя удалена");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AdminDataAccess adm = new AdminDataAccess();
            var user = adm.GetUserByID(id);
            if (user == null) return BadRequest("Пользователя не существует");
            adm.UserDelete(id);
            return Ok("Пользователь удалён");
        }
        
        [HttpGet("{UserID}/test")]
        public IActionResult GetStudentTests(int UserID)
        {
            StudentDataAccess student = new StudentDataAccess();
            Mapper mapper = new Mapper();
            List<TestAttemptDTO> tests = student.GetCompleteTest(UserID);
            tests.AddRange(student.GetIncompleteTest(UserID));
            StudentOutputModel model = mapper.ConvertUserDTOTestAttemptDTOToStudentModel(student.GetUser(UserID), mapper.ConvertTestAttemptDTOToTestAttemptModel(tests));
            return Json(model);
        }
        [HttpGet("{UserID}/test/{TestID}")]
        public IActionResult GetAttemptsByUserIDTestID(int UserID, int TestID)
        {
            StudentDataAccess student = new StudentDataAccess();
            Mapper mapper = new Mapper();
            UserIdTestIdDTO dTO = new UserIdTestIdDTO(UserID, TestID);
            var std = student.GetAttemptsByUserIdTestId(dTO);
            if (std == null) return Ok("Попыток не найдено");
            List <AttemptResultOutputModel> model = mapper.ConvertAttemptDTOToAttemptModel(student.GetAttemptsByUserIdTestId(dTO));
            return Json(model);
        }
        [HttpGet("Attempt/{AttemptID}")]
        public IActionResult GetQuestionAndAnswerByAttemptID(int attemptID)
        {
            TeacherDataAccess teacher = new TeacherDataAccess();
            Mapper mapper = new Mapper();
            List<QuestionAnswerOutputModel> model = mapper.ConvertQuestionAnswerDTOToQuestionAnswerModel(teacher.GetQuestionAndAnswerByAttempt(attemptID));
            return Json(model);
        }
    }
}
