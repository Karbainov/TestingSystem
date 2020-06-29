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
            if (groups == null) { return BadRequest("Неверный запрос"); }
            else {
                foreach (GroupDTO g in groups)
                {
                    GroupOutputModel groupOutModel = new GroupOutputModel();
                    AdminDataAccess gr = new AdminDataAccess();
                    groupOutModel.Id = g.Id;
                    groupOutModel.Name = g.Name;
                    groupOutModel.StartDate = g.StartDate;
                    groupOutModel.EndDate = g.EndDate;
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
                    groupOutModel.Students = studentsOut;
                    groupOutModel.Teachers = teachersOut;  
                    groupOutputModels.Add(groupOutModel);
                } 
                return Ok(groupOutputModels);
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet("{groupId}")]
        public IActionResult GetGroupById(int groupId)
        {
            Mapper mapper = new Mapper();
            AdminDataAccess adm = new AdminDataAccess();
            GroupDTO group = adm.GetGroupById(groupId);
            if (group == null) { return new BadRequestObjectResult("Запрашиваемой группы не существует"); }
            else {
                GroupOutputModel groupOutModel = new GroupOutputModel();
                AdminDataAccess gr = new AdminDataAccess();
                groupOutModel.Id = group.Id;
                groupOutModel.Name = group.Name;
                groupOutModel.StartDate = group.StartDate;
                groupOutModel.EndDate = group.EndDate;
                List<UserDTO> students = gr.GetStudents(group.Id);
                List<UserOutputModel> studentsOut = new List<UserOutputModel>();
                foreach (UserDTO st in students)
                {
                    UserMapper um = new UserMapper();
                    studentsOut.Add(um.ConvertUserDTOToUserOutputModel(st));
                }
                List<UserDTO> teachers = gr.GetTeacherByGroupId(group.Id);
                List<UserOutputModel> teachersOut = new List<UserOutputModel>();
                foreach (UserDTO tc in teachers)
                {
                    UserMapper tm = new UserMapper();
                    teachersOut.Add(tm.ConvertUserDTOToUserOutputModel(tc));
                }
                groupOutModel.Students = studentsOut;
                groupOutModel.Teachers = teachersOut;
                return Ok(groupOutModel); 
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult PostGroup([FromBody]GroupInputModel groupC)
        {
            if (string.IsNullOrWhiteSpace(groupC.Name)) return BadRequest(@"Не заполнено поле ""Название группы"" ");
            Mapper mapper = new Mapper();
            GroupDTO groupDTO = mapper.ConvertGroupInputModelToGroupDTO(groupC);
            AdminDataAccess group = new AdminDataAccess();
            bool result = group.GroupCreate(groupDTO);
            if (result)
            {
                return Ok("Группа успешно создана");
            }
            else
            {
                return BadRequest("Ошибка запроса");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult PutGroup([FromBody]GroupInputModel groupU)
        {
            if (string.IsNullOrWhiteSpace(groupU.Name)) return BadRequest(@"Не заполнено поле ""Название группы"" ");
            Mapper mapper = new Mapper();
            GroupDTO groupDTO = mapper.ConvertGroupInputModelToGroupDTO(groupU);
            AdminDataAccess adm = new AdminDataAccess();
            bool result = adm.GroupUpdate(groupDTO);
            if (!result)
            {
                return new BadRequestObjectResult("Запрашиваемой группы не существует");
            }
            if (result)
            {
                return Ok("Информация о группе успешно обновлена");
            }
            else
            {
                return BadRequest("Ошибка запроса");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{groupId}")] 
        public IActionResult DeleteGroup(int id)
        {
            AdminDataAccess adm = new AdminDataAccess();
            var result = adm.GroupDelete(id);
            if (!result)
            {
                return BadRequest("Выбранной группы не существует");
            }
            if (result)
            {
                return Ok("Группа удалена");
            }
            else
            {
                return BadRequest("Неверный запрос");
            }
        }

        [Authorize(Roles ="Teacher")]
        [HttpGet("teacher/{userId}/statistics")]
        public ActionResult GetStatisticByTeacherId(int userId)
        {
            TeacherDataAccess teacher = new TeacherDataAccess();
            Mapper mapper = new Mapper();
            var groups = teacher.GetGroupsWithStudentsByTeacherId(userId);
            if (groups == null) return BadRequest("Запрашиваемого учителя не существует");
            List<StudentsVSTestsDTO> students = new List<StudentsVSTestsDTO>();
            List<TestDTO> tests = new List<TestDTO>();
            foreach (var g in groups)
            {
                if (g.Students != null)
                    foreach (var s in g.Students)
                    {
                        students.AddRange(teacher.GetTestsByStudentId(s.ID));
                    }
            }
            if (students != null)
                foreach (var s in students)
                {
                    tests.Add(new AuthorDataAccess().GetTestById(s.TestId));
                }
            return Ok(mapper.ConvertStudentsVSTestsDTOAndTeacherGroupsWithStudentsDTOToGroupWithStudentsWithAttemptsOutputModel(students, groups, tests));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{groupId}/student/{userId}")] // добавляем студента в группу
        public IActionResult PostStudentInGroup(int userId, int groupId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            bool result = adm.StudentAddInGroup(userId, groupId);
            if (result)
            {
                return Ok("Студент добавлен в группу");
            }
            else
            {
                return BadRequest("Ошибка запроса");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{groupId}/teacher/{userId}")] // добавляем учителя в группу
        public IActionResult PostTeacherInGroup(int userId, int groupId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            bool result = adm.TeacherAdd(userId, groupId);
            if (result)
            {
                return Ok("Учитель добавлен в группу");
            }
            else
            {
                return BadRequest("Ошибка запроса");
            }
        }
          
                
        [Authorize(Roles = "Admin")]
        [HttpDelete("{groupId}/student/{userId}")] // удаляем студента из группы
        public IActionResult DeleteStudentFromGroup(int groupId, int userId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            bool result = adm.DeleteStudentFromGroup(userId, groupId);
            if (result)
            {
                return Ok("Студент удален из группы");
            }
            else
            {
                return BadRequest("Ошибка запроса");
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{groupId}/teacher/{userId}")] // удаляем учителя из группы
        public IActionResult DeleteTeacherFromGroup(int userId, int groupId)
        {
            AdminDataAccess adm = new AdminDataAccess();
            bool result = adm.DeleteTeacherFromGroup(userId, groupId);
            if (result)
            {
                return Ok("Учитель удален из группы");
            }
            else
            {
                return BadRequest("Ошибка запроса");
            }
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("teacher/{userId}")]
        public IActionResult GetGroupsWithStudentsByTeacherId(int userId)
        {
            GroupManager teacher = new GroupManager();
            Mapper mapper = new Mapper();
            var result =
                mapper.ConvertTeacherGroupsWithStudentsDTOToGroupWithStudentsOutputModel
                (teacher.GetGroupsWithStudentsByTeacherID(userId));
            if (result == null) { return BadRequest("Неверный запрос"); }
            return Ok(result);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost("test")]
        public IActionResult PostTestForGroup([FromBody]TestGroupInputModel test)
        {
            AdminDataAccess adm = new AdminDataAccess();
            var group = adm.GetGroupById(test.groupId.Value);
            if (group == null) return BadRequest("Группа не существует");
            AuthorDataAccess author = new AuthorDataAccess();
            var t = author.GetTestById(test.testId.Value);
            if (t == null) return BadRequest("Тест не существует");
            if (test.testId == null) return BadRequest("Не выбран тест");
            if (test.groupId == null) return BadRequest("Не выбрана группа");
            if (string.IsNullOrWhiteSpace(test.startDate)) return BadRequest("Отсутствует дата начала теста"); 
            if (string.IsNullOrWhiteSpace(test.endDate)) return BadRequest("Отсутствует дата окончания теста");
            Mapper mapper = new Mapper();
            TeacherDataAccess teacher = new TeacherDataAccess();
            int id = teacher.SetTestForGroup(mapper.ConvertTestGroupInputModelToTestGroupDTO(test));
            return Ok(id);
        }
    }
}
