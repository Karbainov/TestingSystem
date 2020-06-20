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


        //[HttpGet]
        //public List<UserOutputModel> Get()
        //{
        //    List<UserOutputModel> allUsers = new List<UserOutputModel>();
        //    Map mapper = new Map();
        //    AdminDataAccess adm = new AdminDataAccess();
        //    foreach(UserDTO user in adm.GetAllUsers())
        //    {
        //        allUsers.Add(mapper.ConvertUserDTOToUserOutputModel(user));
        //    }
        //    return allUsers;
        //}


        [HttpPost]
        public void PostUser([FromBody] UserInputModel user)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            adm.UserCreate(mapper.ConvertUserInputModelToGroupDTO(user));

        }
        
        [HttpPost("role")]
        public void PostUserRole([FromBody] UserRoleInputModel userRole)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            adm.UserRoleCreate(mapper.ConvertUserRoleInputModelToUserRoleDTO(userRole));
        }
        
        [HttpGet("role")]
        public List<RoleOutputModel> GetRole()
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            List<RoleDTO> roles = adm.GetRole();
            List<RoleOutputModel> rolesOut = new List<RoleOutputModel>();
            foreach (RoleDTO r in roles)
            {
                rolesOut.Add(mapper.ConvertRoleDTOToRoleOutputModel(r));
            }

            return rolesOut;
        }
        
        [HttpGet("{userId}/role")]
        public List<RoleOutputModel> GetRoleByUserId(int userId)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            List<RoleDTO> roles = adm.GetRoleByUserId(userId);
            List<RoleOutputModel> rolesOut = new List<RoleOutputModel>();
            foreach (RoleDTO r in roles)
            {
                rolesOut.Add(mapper.ConvertRoleDTOToRoleOutputModel(r));
            }
            return rolesOut;
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
            
            foreach(UserDTO user in adm.GetUsersByRoleID(roleID))
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
            UserDTO getUser = adm.GetUserbyID(id);
            if (getUser == null) { return new BadRequestObjectResult("Пользователя с таким id не существует"); }
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
            adm.UserUpdate(mapper.ConvertUserInputModelToGroupDTO(user));
            return new OkObjectResult("Пользователь добавлен");
        }
        
        [HttpDelete("{userId}/role/{roleId}")]
        public IActionResult DeleteUserRole(int userId, int roleId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.UserRoleDelete(userId, roleId);
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.UserDelete(id);
            return new OkResult();
        }
        
        [HttpGet("{UserID}/user")]
        public IActionResult GetStudentTests(int UserID)
        {
            StudentDataAccess student = new StudentDataAccess();
            Mapper mapper = new Mapper();
            List<TestAttemptDTO> tests = student.GetCompleteTest(UserID);
            tests.AddRange(student.GetIncompleteTest(UserID));
            StudentOutputModel model = mapper.ConvertUserDTOTestAttemptDTOToStudentModel(student.GetUser(UserID), mapper.ConvertTestAttemptDTOToTestAttemptModel(tests));
            return Json(model);
        }
        [HttpGet("Tests/{UserID}/{TestID}")]
        public IActionResult GetAttemptsByUserIDTestID(int UserID, int TestID)
        {
            StudentDataAccess student = new StudentDataAccess();
            Mapper mapper = new Mapper();
            UserIdTestIdDTO dTO = new UserIdTestIdDTO(UserID, TestID);
            List<AttemptResultOutputModel> model = mapper.ConvertAttemptDTOToAttemptModel(student.GetAttemptsByUserIdTestId(dTO));
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
