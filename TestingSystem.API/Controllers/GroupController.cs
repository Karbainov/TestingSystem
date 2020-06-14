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
using TestingSystem.API;
using TestingSystem.API.Models.Output;
using TestingSystem.Data.StoredProcedure;

namespace TestingSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
       
        private readonly ILogger<GroupController> _logger;

        public GroupController(ILogger<GroupController> logger)
        {
            _logger = logger;
        }

             
        [HttpGet("admin")]  // htpps://localhost/group
        public List<GroupOutputModel> GetAllGroups()
        {
            Mapper mapper = new Mapper();
            AdminDataAccess adm = new AdminDataAccess();
            List<GroupOutputModel> groupOutputModels = new List<GroupOutputModel>();
                        
            List<GroupDTO> groups =  adm.GetAllGroups();
            foreach (GroupDTO g in groups)
            {
                GroupManager gr = new GroupManager();
                GroupOutputModel www = new GroupOutputModel();
                www.Id = g.Id;
                www.Name = g.Name;
                www.StartDate = g.StartDate;
                www.EndDate = g.EndDate;
                List<UserDTO> students= gr.GetAllStudents(g.Id);
                List<UserOutputModel> studentsout = new List<UserOutputModel>();
                foreach (UserDTO st in students)
                {
                    UserMapper um = new UserMapper();
                    studentsout.Add(um.ConvertUserDTOToUserOutputModel(st));

                }
                List<UserDTO> teachers = gr.GetTeacherByGroupId(g.Id);
                List<UserOutputModel> teachersout = new List<UserOutputModel>();
                foreach (UserDTO tc in teachers)
                {
                    UserMapper tm = new UserMapper();
                    usersout.Add(tm.ConvertUserDTOToUserOutputModel(tc));
                }
                www.students = studentsout;
                www.teachers = teachersout;  //w=все тичеры
                groupOutputModels.Add(www);

               
            }
            return groupOutputModels;


        }

               
        [HttpPost("admin")]
        public void PostGroup([FromBody] GroupOutputModel group)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.GroupCreate(group);
           
        }

        [HttpGet("{id}")]
        public GroupDTO GetGroupById(int id)
        {
            AdminDataAccess adm = new AdminDataAccess();
            return adm.GetGroupById(id);
        }
        
        [HttpGet("{id}/user")]
        public GroupDTO GetUserListByGroupId(int id)
        {
            AdminDataAccess adm = new AdminDataAccess();
            return adm.GetGroupById(id); // изменить
        }
        
        [HttpPost("{groupID}/student/{userID}")] // GET http://localhost:5557/group/id/student/id	
        public void PostStudentInGroup(int userID, int groupID)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.StudentAdd(userID, groupID);
        }
        
        [HttpPost("{groupID}/teacher/{userID}")] // GET http://localhost:5557/group/id/teacher/id	
        public void PostTeacherInGroup(int userID, int groupID)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.TeacherAdd(userID, groupID);
        }
        
        [HttpPut]
        public void PutGroup([FromBody]GroupDTO groupU)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.GroupUpdate(groupU);

        }

        [HttpDelete] //url удаляем из group

        public void DeleteGroupById([FromBody] int id)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.GroupDelete(id);

        }

        [HttpDelete] // удаляем студента из группы
        public void DeleteStudent([FromBody]StudentGroupDTO studentD)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.StudentDelete(studentD);
        }

        [HttpDelete] // удаляем учителя из группы
        public void DeleteTeacher([FromBody]TeacherGroupDTO teacherD)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.TeacherDelete(teacherD);
        }
    }
}
