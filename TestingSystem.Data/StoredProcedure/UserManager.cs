using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;
using Dapper;
using System.Linq;
using System.Data;

namespace TestingSystem.Data.StoredProcedure
{
    public class UserManager
    {
        
        public int AddUserWithRole(UserWithRoleDTO user)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression =
                    "AddUserWithRole @FirstName, @LastName, @BirthDate, @Login, @Password, @Email, @Phone, @RoleID";
                return connection.Query<int>(sqlExpression, user ).FirstOrDefault();
            }
        }

        public List<RoleDTO> GetRoleByUserId(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetRoleByUserId";
                return connection.Query<RoleDTO>(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<UserPositionDTO> GetUserVSRole()
        {
            IDbConnection usPos = Connection.GetConnection();
            List<UserPositionDTO> userPositions;
            using (usPos)
            {
                var userDictionary = new Dictionary<int, UserPositionDTO>();


                usPos.Query<UserPositionDTO, RoleIdDTO, UserPositionDTO>(
                    "User_Position",
                    (user, roles) =>
                    {
                        UserPositionDTO userEntry;

                        if (!userDictionary.TryGetValue(user.Id, out userEntry))
                        {
                            userEntry = user;
                            userEntry.Roles = new List<RoleIdDTO>();
                            userDictionary.Add(userEntry.Id, userEntry);
                        }

                        userEntry.Roles.Add(roles);
                        return userEntry;
                    },
                    splitOn: "RoleID")
                .ToList();
                userPositions = new List<UserPositionDTO>(userDictionary.Values);
            }
            return userPositions;
        }

        public List<StudentsVSTestsDTO> GetStudentVsTests(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "AllStudentTests ";
                return connection.Query<StudentsVSTestsDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<StudentsVSTestsDTO> GetStudentsByTestId(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "AllStudentsByTestId";
                return connection.Query<StudentsVSTestsDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<StudentsVSTestsDTO> GetTestsByStudentId(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "AllTestsByStudentId";
                return connection.Query<StudentsVSTestsDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TestAttemptDTO> GetIncompleteTests(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_GetIncompleteTests";
                return connection.Query<TestAttemptDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<UserDTO> GetUsersByRoleID(int roleId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetUsersByRoleId";
                return connection.Query<UserDTO>(sqlExpression, new { roleId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<GroupDTO> GetGroupsAndStudentsByTeacherID(int teacherId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetGroupsAndStudentsByTeacherID";
                return connection.Query<GroupDTO>(sqlExpression, new { teacherId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<UserByLoginDTO> GetUserAndItRole(string login)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetUserAndItRole";
                return connection.Query<UserByLoginDTO>(sqlExpression, new { login }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public UserPositionDTO GetUserWithRolesByUserId(int userId)
        {

            IDbConnection usPos = Connection.GetConnection();
            UserPositionDTO userP;
            using (usPos)
            {
                var userDictionary = new Dictionary<int, UserPositionDTO>();


                usPos.Query<UserPositionDTO, RoleIdDTO, UserPositionDTO>(
                    "GetUserWithRoleByUserId",
                    (user, roles) =>
                    {
                        UserPositionDTO userEntry;

                        if (!userDictionary.TryGetValue(user.Id, out userEntry))
                        {
                            userEntry = user;
                            userEntry.Roles = new List<RoleIdDTO>();
                            userDictionary.Add(userEntry.Id, userEntry);
                        }

                        userEntry.Roles.Add(roles);
                        return userEntry;
                    },
                    new { userId },
                    splitOn: "RoleID",
                    commandType:CommandType.StoredProcedure)
                .FirstOrDefault();
                if (userDictionary.ContainsKey(userId))
                {
                    userP = userDictionary[userId];
                    return userP;
                }
            }
            return null;
        }
    }
}
