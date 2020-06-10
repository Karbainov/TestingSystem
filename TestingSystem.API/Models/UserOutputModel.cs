using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.StoredProcedure.CRUD;

namespace TestingSystem.API.InputOutputModels
{
    public class UserOutputModel
    {
        public int userID;
        public List<UserDTO> user;
    }
}
