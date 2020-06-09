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
    public class UserController : ControllerBase
    {



        private readonly ILogger<GroupController> _logger;

        public UserController(ILogger<GroupController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public List<UserDTO> Get()
        {
            AdminDataAccess adm = new AdminDataAccess();
            return adm.GetAllUsers();
        }


        [HttpPost]
        public void Post([FromBody] UserDTO user)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.UserCreate(user);

        }

        [HttpGet]
        public List<UserRoleDTO> GetAllUsersRoles()
        {
            AdminDataAccess adm = new AdminDataAccess();
            return adm.GetAllUserRoles();
        }

        [HttpGet("{roleID}")]
        public List<UserRoleDTO> GetUserRolesByRoleID(int roleID)
        {
            AdminDataAccess adm = new AdminDataAccess();
            return adm.GetUserRolesByRoleID(roleID);
        }

        [HttpGet("{id}")]
        public UserDTO GetUserById(int id)
        {
            AdminDataAccess adm = new AdminDataAccess();
            return adm.GetUserbyID(id);
        }

        [HttpPut]
        public void Put([FromBody] UserDTO user)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.UserUpdate(user);

        }

        [HttpDelete]

        public void Delete([FromBody] UserDTO user)
        {
            AdminDataAccess adm = new AdminDataAccess();
            adm.UserDelete(user);

        }
    }
}
