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

             
        [HttpGet]  // htpps://localhost/group
        public List<GroupDTO> Get()
        {
            AdminDataAccess adm = new AdminDataAccess();
            return adm.GetAllGroups();
        }

               
        [HttpPost]
        public void Post([FromBody]GroupDTO groupC)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.GroupCreate(groupC);
           
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
        public void Put([FromBody]GroupDTO groupU)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.GroupUpdate(groupU);

        }

        [HttpDelete] //url удаляем из group

        public void Delete([FromBody] int id)
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
