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
        //public int User_DeleteAccount(SqlConnection connection, UserDTO user)//удаление студента и всего, что с ним связано
        //{
        //    connection.Open();
        //    string sqlExpression = "User_DeleteAccount";
        //    SqlCommand command = new SqlCommand(sqlExpression, connection);
        //    command.CommandType = System.Data.CommandType.StoredProcedure;

        //    SqlParameter userParam = new SqlParameter("@UserID", user.ID);
        //    command.Parameters.Add(userParam);
        //    return command.ExecuteNonQuery();
        //}

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
            List<UserPositionDTO> userPositions = new List<UserPositionDTO>();
            using (usPos)
            {
                userPositions = usPos.Query<UserPositionDTO>("User_Position").ToList();
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
    }
}
