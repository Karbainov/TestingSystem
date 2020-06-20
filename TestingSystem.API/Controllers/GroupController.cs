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
    public class GroupController : Controller
    {
        private readonly ILogger<GroupController> _logger;
        
        public GroupController(ILogger<GroupController> logger)
        {
            _logger = logger;
        }

        [HttpGet("admin")]
        public IActionResult GetAllGroups()
        {         
            AdminDataAccess adm = new AdminDataAccess();
            List<GroupOutputModel> groupOutputModels = new List<GroupOutputModel>();
            List<GroupDTO> groups = adm.GetAllGroups();
            if (groups == null) { return new BadRequestObjectResult("Ошибка сервера"); }
            else {
                foreach (GroupDTO g in groups)
                {
                    GroupOutputModel www = new GroupOutputModel();
                    AdminDataAccess gr = new AdminDataAccess();
                    www.Id = g.Id;
                    www.Name = g.Name;
                    www.StartDate = g.StartDate;
                    www.EndDate = g.EndDate;
                    List<UserDTO> students = gr.GetAllStudents(g.Id);
                    List<UserOutputModel> studentsOut = new List<UserOutputModel>();
                    foreach (UserDTO st in students)
                    {
                        UserMapper um = new UserMapper();
                        studentsOut.Add(um.ConvertUserDTOToUserOutputModel(st));
                    }
                    List<UserDTO> teachers = gr.GetTeacherByGroupId(g.Id);
                    List<UserOutputModel> teachersOut = new List<UserOutputModel>();
                    foreach (UserDTO tc in teachers)
                    {
                        UserMapper tm = new UserMapper();
                        teachersOut.Add(tm.ConvertUserDTOToUserOutputModel(tc));
                    }
                    www.Students = studentsOut;
                    www.Teachers = teachersOut;  
                    groupOutputModels.Add(www);
                } 
                return Json(groupOutputModels);
            }
        }
        
        [HttpPost]
        public void GroupPost([FromBody]GroupInputModel groupC)
        {
            Mapper mapper = new Mapper();
            GroupDTO groupDTO = mapper.ConvertGroupInputModelToGroupDTO(groupC);
            AdminDataAccess group = new AdminDataAccess();
            group.GroupCreate(groupDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetGroupById(int id)
        {
            Mapper mapper = new Mapper();
            AdminDataAccess adm = new AdminDataAccess();
            GroupDTO group = adm.GetGroupById(id);
            if (group == null) { return new BadRequestObjectResult("Группы с таким id не существует"); }
            else {
                return Json(mapper.ConvertGroupDTOToGroupOutputModel(group)); 
            }
        }
        
        [HttpPost("{groupID}/student/{userID}")]
        public void PostStudentInGroup(int userId, int groupId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.StudentAdd(userId, groupId);
        }
        
        [HttpPost("{groupID}/teacher/{userID}")]
        public void PostTeacherInGroup(int userId, int groupId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.TeacherAdd(userId, groupId);
        }

        [HttpPut]
        public void GroupPut([FromBody]GroupInputModel groupU)
        {
            Mapper mapper = new Mapper();
            GroupDTO groupdto = mapper.ConvertGroupInputModelToGroupDTO(groupU);
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
        public void DeleteStudentFromGroup(int studentId, int groupId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.DeleteStudentFromGroup(studentId, groupId);
        }

        [HttpDelete] // удаляем учителя из группы
        public void DeleteTeacherFromGroup(int studentId, int groupId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.DeleteTeacherFromGroup(studentId, groupId);
        }
    }
}
