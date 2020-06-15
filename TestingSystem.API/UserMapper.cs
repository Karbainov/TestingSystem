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
using TestingSystem.API.Models.Input;
using TestingSystem.API.Models.Output;

namespace TestingSystem.API
{
    public class UserMapper
    {
        public UserDTO ConvertUserInputModelToGroupDTO (UserInputModel userIn)
        {
            UserDTO user = new UserDTO(userIn.ID, userIn.FirstName, userIn.LastName, userIn.BirthDate, userIn.Login, userIn.Password, userIn.Email, userIn.Phone);
            return user;
        }

        public UserOutputModel ConvertUserDTOToUserOutputModel(UserDTO user)
        {
            UserOutputModel userOut = new UserOutputModel(user.ID, user.FirstName, user.LastName, user.BirthDate, user.Login, user.Password, user.Email, user.Phone);
            return userOut;
        }

        public UserWithRolesOutputModel ConvertUserPositionDTOToUserWithRolesOutputModel(UserPositionDTO user)
        {
            List<string> userRoles = new List<string>();
            foreach(RoleIdDTO n in user.Roles)
            {
                userRoles.Add(n.Name);
            }
            UserWithRolesOutputModel userOut = new UserWithRolesOutputModel(user.Id, user.FirstName, user.LastName, user.BirthDate, user.Login, user.Password, user.Email, user.Phone, userRoles);
            return userOut;
        }

        public List<UserWithRolesOutputModel> ConvertUserPositionDTOsToUserWithRolesOutputModels(List<UserPositionDTO> users)
        {
            List<UserWithRolesOutputModel> usersOut = new List<UserWithRolesOutputModel>();
            UserMapper mapper = new UserMapper();

            foreach (UserPositionDTO u in users)
            {
                usersOut.Add(mapper.ConvertUserPositionDTOToUserWithRolesOutputModel(u));
            }

            return usersOut;
        }
    }
}
