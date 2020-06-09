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

namespace TestingSystem.Controllers.Controllers
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
        public void Get()
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.GetAllGroup();
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

    }
}
