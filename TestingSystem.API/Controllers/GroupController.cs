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
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllGroups()
        {         
            AdminDataAccess adm = new AdminDataAccess();
            List<GroupOutputModel> groupOutputModels = new List<GroupOutputModel>();
            List<GroupDTO> groups = adm.GetAllGroups();
            if (groups == null) { return new BadRequestObjectResult("Ошибка сервера"); }
            else {
                foreach (GroupDTO g in groups)
                {
                    GroupOutputModel groupoutmodel = new GroupOutputModel();
                    AdminDataAccess gr = new AdminDataAccess();
                    groupoutmodel.Id = g.Id;
                    groupoutmodel.Name = g.Name;
                    groupoutmodel.StartDate = g.StartDate;
                    groupoutmodel.EndDate = g.EndDate;
                    List<UserDTO> students = gr.GetStudents(g.Id);
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
                    groupoutmodel.Students = studentsOut;
                    groupoutmodel.Teachers = teachersOut;  
                    groupOutputModels.Add(groupoutmodel);
                } 
                return Json(groupOutputModels);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void PostGroup([FromBody]GroupInputModel groupC)
        {
            Mapper mapper = new Mapper();
            GroupDTO groupDTO = mapper.ConvertGroupInputModelToGroupDTO(groupC);
            AdminDataAccess group = new AdminDataAccess();
            group.GroupCreate(groupDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult PutGroup([FromBody]GroupInputModel groupU)
        {
            Mapper mapper = new Mapper();
            GroupDTO groupDTO = mapper.ConvertGroupInputModelToGroupDTO(groupU);
            AdminDataAccess adm = new AdminDataAccess();
            int result = adm.GroupUpdate(groupDTO);
            if (result == 0)
            {
                return new BadRequestObjectResult("Requested group does not exist");
            }
            if (result == 1)
            {
                return new OkObjectResult("Group information is updated");
            }
            else
            {
                return new BadRequestObjectResult("DataBase error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete] //url удаляем из group
        public void DeleteGroup([FromBody] int id)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.GroupDelete(id);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("{groupId}")]
        public IActionResult GetGroupById(int groupId)
        {
            Mapper mapper = new Mapper();
            AdminDataAccess adm = new AdminDataAccess();
            GroupDTO group = adm.GetGroupById(groupId);
            if (group == null) { return new BadRequestObjectResult("Группы с таким id не существует"); }
            else {
                return Json(mapper.ConvertGroupDTOToGroupOutputModel(group)); 
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{groupId}/student/{userId}")]
        public void PostStudentInGroup(int userId, int groupId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.StudentAddInGroup(userId, groupId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{groupId}/teacher/{userId}")]
        public void PostTeacherInGroup(int userId, int groupId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.TeacherAdd(userId, groupId);
        }
          
                
        [Authorize(Roles = "Admin")]
        [HttpDelete("{groupId}/student/{userId}")] // удаляем студента из группы
        public void DeleteStudentFromGroup(int groupId, int userId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.DeleteStudentFromGroup(userId, groupId);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{groupId}/teacher/{userId}")] // удаляем учителя из группы
        public void DeleteTeacherFromGroup(int userId, int groupId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.DeleteTeacherFromGroup(userId, groupId);
        }

        [HttpGet("teacher/{id}")]
        public ActionResult GetGroupsWithStudentsByTeacherID(int id)
        {
            GroupManager teacher = new GroupManager();
            Mapper mapper = new Mapper();
            return Ok(mapper.ConvertTeacherGroupsWithStudentsDTOToGroupWithStudentsOutputModel(teacher.GetGroupsWithStudentsByTeacherID(id)));
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost("test")]
        public IActionResult PostTestForGroup([FromBody]TestGroupInputModel test)
        {
            if (test.testId == null) return BadRequest("Не выбран тест");
            if (test.groupId == null) return BadRequest("не выбрана группа");
            Mapper mapper = new Mapper();
            TeacherDataAccess teacher = new TeacherDataAccess();
            int id = teacher.SetTestForGroup(mapper.ConvertTestGroupInputModelToTestGroupDTO(test));
            return Ok(id);
        }
    }
}
