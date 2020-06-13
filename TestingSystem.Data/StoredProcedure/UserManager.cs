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

        public int AddStudentAndPutThemIntoGroup(UserGroupDTO userGroup)//добавление студента сразу в группу
        {
            using(IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Create @GroupID,@FirstName,@LastName,@BirthDate,@Login,@Password,@Email,@Phone";
                return connection.Query<int>(sqlExpression, userGroup).FirstOrDefault();
            }
            
        }
      
        public void AddUserWithRole (UserWithRoleDTO user)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "AddUserWithRole @FirstName, @LastName, @BirthDate, @Login, @Password, @Email, @Phone, @RoleID";
            connection.Execute(sqlExpression, user);
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
                //.Distinct()
                .ToList();
                userPositions = new List<UserPositionDTO>(userDictionary.Values);
                //foreach(UserPositionDTO u in userDictionary.Values)
                //{
                //    Console.WriteLine($"{u.FirstName}, {u.LastName}, {u.BirthDate}, {u.Login}, {u.Password}, {u.Email}, {u.Phone}");
                //    foreach (RoleDTO r in u.Roles)
                //    {
                //        Console.WriteLine($"{r.RoleID}, {r.Name}");
                //    }
                //    Console.WriteLine("-", 50);
                //}
                //userPositions = usPos.Query<UserPositionDTO>("User_Position").ToList();
            }
            
            return userPositions;
        }

        public List<AllStudentTestsDTO> GetStudentVsTests(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "AllStudentTests ";
                return connection.Query<AllStudentTestsDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
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

        public List<GroupDTO> GetGroupsAndStudentsByTeacherID(int TeacherID) 
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetGroupsAndStudentsByTeacherID";
                return connection.Query<GroupDTO>(sqlExpression, new { TeacherID }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
