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

namespace TestingSystem.API.Controllers
{
        [ApiController]
        [Route("[controller]")]
    public class UserController : ControllerBase
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
        public List<UserWithRolesOutputModel> GetAllUsersWithRoles()
        {
            AdminDataAccess adm = new AdminDataAccess();
            List<UserPositionDTO> users = adm.GetAllUsersWithRoles();
            UserMapper mapper = new UserMapper();

            return mapper.ConvertUserPositionDTOsToUserWithRolesOutputModels(users);
        }
        
        
        [HttpGet("role/{roleID}")]
        public List<UserOutputModel> GetUsersByRoleID(int roleID)
        {
            AdminDataAccess adm = new AdminDataAccess();
            List<UserOutputModel> allUsers = new List<UserOutputModel>();
            UserMapper mapper = new UserMapper();
            
            foreach(UserDTO user in adm.GetUsersByRoleID(roleID))
            {
                allUsers.Add(mapper.ConvertUserDTOToUserOutputModel(user));
            }
            return allUsers;
        }
        
        [HttpGet("{id}")]
        public UserOutputModel GetUserById(int id)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            return mapper.ConvertUserDTOToUserOutputModel(adm.GetUserbyID(id));
        }

        [HttpPut]
        public void Put([FromBody] UserInputModel user)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            adm.UserUpdate(mapper.ConvertUserInputModelToGroupDTO(user));
        }
        
        [HttpDelete("{userId}/role/{roleId}")]
        public void DeleteUserRole(int userId, int roleId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.UserRoleDelete(userId, roleId);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.UserDelete(id);
        }
        
        [HttpGet("{UserID}/user")]
        public StudentOutputModel GetStudentTests(int UserID)
        {
            StudentDataAccess student = new StudentDataAccess();
            Mapper mapper = new Mapper();
            List<TestAttemptDTO> tests = student.GetCompleteTest(UserID);
            tests.AddRange(student.GetIncompleteTest(UserID));
            StudentOutputModel model = mapper.ConvertUserDTOTestAttemptDTOToStudentModel(student.GetUser(UserID), mapper.ConvertTestAttemptDTOToTestAttemptModel(tests));
            return model;
        }
        [HttpGet("Tests/{UserID}/{TestID}")]
        public List<AttemptResultOutputModel> GetAttemptsByUserIDTestID(int UserID, int TestID)
        {
            StudentDataAccess student = new StudentDataAccess();
            Mapper mapper = new Mapper();
            UserIdTestIdDTO dTO = new UserIdTestIdDTO(UserID, TestID);
            List<AttemptResultOutputModel> model = mapper.ConvertAttemptDTOToAttemptModel(student.GetAttemptsByUserIdTestId(dTO));
            return model;
        }
        [HttpGet("Attempt/{AttemptID}")]
        public List<QuestionAnswerOutputModel> GetQuestionAndAnswerByAttemptID(int attemptID)
        {
            TeacherDataAccess teacher = new TeacherDataAccess();
            Mapper mapper = new Mapper();
            List<QuestionAnswerOutputModel> model = mapper.ConvertQuestionAnswerDTOToQuestionAnswerModel(teacher.GetQuestionAndAnswerByAttempt(attemptID));
            return model;
        }
        
       
    }
}
