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
        public UserDTO ConvertUserInputModelToUserDTO (UserInputModel userIn)
        {
            UserDTO user = new UserDTO(userIn.ID, userIn.FirstName, userIn.LastName, userIn.BirthDate, userIn.Login, userIn.Password, userIn.Email, userIn.Phone);
            return user;
        }
        
        public UserRoleDTO ConvertUserRoleInputModelToUserRoleDTO (UserRoleInputModel userRoleIn)
        {
            UserRoleDTO userRole = new UserRoleDTO(userRoleIn.ID, userRoleIn.UserID, userRoleIn.RoleID);
            return userRole;
        }

        public UserOutputModel ConvertUserDTOToUserOutputModel(UserDTO user)
        {
            UserOutputModel userOut = new UserOutputModel(user.ID, user.FirstName, user.LastName, user.BirthDate, user.Login, user.Password, user.Email, user.Phone);
            return userOut;
        }
        public StudentsGroupOutputModel ConvertUserDTOToStudentsGroupOutputModel(UserDTO user)
        {
            StudentsGroupOutputModel userOut = new StudentsGroupOutputModel(user.ID, user.FirstName, user.LastName, user.Email, user.Phone);
            return userOut;
        }
        public RoleOutputModel ConvertRoleDTOToRoleOutputModel(RoleDTO role) // скорее всего, нужен foreach, т.к. получаем не одну строку
        {
            RoleOutputModel roleOut = new RoleOutputModel(role.ID, role.Name);
            return roleOut;
        }

        public UserWithRolesOutputModel ConvertUserPositionDTOToUserWithRolesOutputModel(UserPositionDTO user) // нужен ли foreach?
        {
            List<string> userRoles = new List<string>();
            foreach(RoleIdDTO n in user.Roles)
            {
                if (n != null)
                {
                    userRoles.Add(n.Name);
                }
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
        public List<UserOutputModel> ConvertListUserDTOToListUserOutputModel(List<UserDTO> users)
        {
            UserMapper mapper = new UserMapper();
            List<UserOutputModel> usersOut = new List<UserOutputModel>();
            foreach (var u in users)
            {
                usersOut.Add(mapper.ConvertUserDTOToUserOutputModel(u));
            }
            return usersOut;
        }
        public List<StudentsGroupOutputModel> ConvertListUserDTOToListStudentsGroupOutputModel(List<UserDTO> users)
        {
            UserMapper mapper = new UserMapper();
            List<StudentsGroupOutputModel> usersOut = new List<StudentsGroupOutputModel>();
            foreach (var u in users)
            {
                usersOut.Add(mapper.ConvertUserDTOToStudentsGroupOutputModel(u));
            }
            return usersOut;
        }

    }
}
