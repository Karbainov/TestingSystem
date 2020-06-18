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
using TestingSystem.Data.StoredProcedure;
using TestingSystem.API.Models.Output;
using TestingSystem.API.Models.Input;

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
            AdminDataAccess adm = new AdminDataAccess();
            List<GroupOutputModel> groupOutputModels = new List<GroupOutputModel>();
            List<GroupDTO> groups = adm.GetAllGroups();
            foreach (GroupDTO g in groups)
            {
                GroupOutputModel www = new GroupOutputModel();
                AdminDataAccess gr = new AdminDataAccess();
                www.Id = g.Id;
                www.Name = g.Name;
                www.StartDate = g.StartDate;
                www.EndDate = g.EndDate;
                List<UserDTO> students = gr.GetAllStudents(g.Id);
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
                    teachersout.Add(tm.ConvertUserDTOToUserOutputModel(tc));
                }
                www.Students = studentsout;
                www.Teachers = teachersout;  
                groupOutputModels.Add(www);

            }
            return groupOutputModels;
            
        }
        
        [HttpPost]
        public void GroupPost([FromBody]GroupInputModel groupC)
        {
            Mapper mapper = new Mapper();
            GroupDTO groupdto = mapper.GroupInputModelToGroupDTO(groupC);
            AdminDataAccess group = new AdminDataAccess();
            group.GroupCreate(groupdto);

        }

        [HttpGet("{id}")]
        public GroupOutputModel GetGroupById(int id)
        {
            Mapper mapper = new Mapper();
            AdminDataAccess adm = new AdminDataAccess();
            GroupOutputModel gom = mapper.GroupDTOToGroupOutputModel(adm.GetGroupById(id));
            return gom;
        }
        
      
        
        [HttpPost("{groupID}/student/{userID}")] // POST http://localhost:5557/group/5/student/82	
        public void PostStudentInGroup(int userID, int groupID)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.StudentAdd(userID, groupID);
        }
        
        [HttpPost("{groupID}/teacher/{userID}")] // POST http://localhost:5557/group/id/teacher/id	
        public void PostTeacherInGroup(int userID, int groupID)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.TeacherAdd(userID, groupID);
        }

        [HttpPut]
        public void GroupPut([FromBody]GroupInputModel groupU)
        {
            Mapper mapper = new Mapper();
            GroupDTO groupdto = mapper.GroupInputModelToGroupDTO(groupU);
            AdminDataAccess group = new AdminDataAccess();
            group.GroupUpdate(groupdto);

        }

        [HttpDelete] //url удаляем из group

        public void Delete([FromBody] int id)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.GroupDelete(id);

        }

        [HttpDelete] // удаляем студента из группы
        public void DeleteStudentFromGroup(int studentID, int groupID)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.DeleteStudentFromGroup(studentID, groupID);
        }

        [HttpDelete] // удаляем учителя из группы
        public void DeleteTeacherFromGroup(int studentID, int groupID)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.DeleteTeacherFromGroup(studentID, groupID);
        }
    }
}
