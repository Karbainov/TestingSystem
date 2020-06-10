using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.StoredProcedure.CRUD;


namespace TestingSystem.API.InputOutputModels
{
    public class UserDTOToUserOutPutModel
    {
        public static UserOutputModel Mapp(int userId, List<UserDTO> user)
        {
            UserOutputModel usom = new UserOutputModel();
            usom.userID = userId;
            usom.user = user;
            return usom;
        }
    }
}
