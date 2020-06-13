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
        public void Post([FromBody] UserInputModel user)
        {
            UserMapper mapper = new UserMapper();
            AdminDataAccess adm = new AdminDataAccess();
            adm.UserCreate(mapper.ConvertUserInputModelToGroupDTO(user));

        }
        
        [HttpGet]
        public List<UserWithRolesOutputModel> GetAllUsersWithRoles()
        {
            AdminDataAccess adm = new AdminDataAccess();
            List<UserPositionDTO> users = adm.GetAllUsersWithRoles();
            List<UserWithRolesOutputModel> usersOut = new List<UserWithRolesOutputModel>();
            UserMapper mapper = new UserMapper();

            foreach (UserPositionDTO u in users)
            {
                usersOut.Add(mapper.ConvertUserPositionDTOToUserWithRolesOutputModel(u));
            }

            return usersOut;
        }
        

        [HttpGet("role/{roleID}")]
        public List<UserRoleDTO> GetUsersByRoleID(int roleID)
        {
            AdminDataAccess adm = new AdminDataAccess();
            return adm.GetUserRolesByRoleID(roleID);
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

        [HttpDelete]

        public void Delete([FromBody] int id)
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
            StudentOutputModel model = mapper.UserDTOTestAttemptDTOToStudentModel(student.GetUser(UserID), mapper.TestAttemptDTOToTestAttemptModel(tests));
            return model;
        }
        [HttpGet("Tests/{UserID}/{TestID}")]
        public List<AttemptResultOutputModel> GetAttemptsByUserIDTestID(int UserID, int TestID)
        {
            StudentDataAccess student = new StudentDataAccess();
            Mapper mapper = new Mapper();
            UserIdTestIdDTO dTO = new UserIdTestIdDTO(UserID, TestID);
            List<AttemptResultOutputModel> model = mapper.attemptDTOToAttemptModel(student.GetAttemptsByUserIdTestId(dTO));
            return model;
        }
        [HttpGet("Attempt/{AttemptID}")]
        public List<QuestionAnswerOutputModel> GetQuestionAndAnswerByAttemptID(int attemptID)
        {
            TeacherDataAccess teacher = new TeacherDataAccess();
            Mapper mapper = new Mapper();
            List<QuestionAnswerOutputModel> model = mapper.QuestionAnswerDTOToQuestionAnswerModel(teacher.GetQuestionAndAnswerByAttempt(attemptID));
            return model;
        }
    }
}
