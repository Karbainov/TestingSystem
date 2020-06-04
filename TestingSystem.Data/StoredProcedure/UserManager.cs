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

        public int User_Student_Group_Add(SqlConnection connection, UserDTO user, GroupDTO group)//добавление студента сразу в группу
        {
            connection.Open();
            string sqlExpression = "User_Create";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter GroupParam = new SqlParameter("@GroupID", group.id);
            command.Parameters.Add(GroupParam);

            SqlParameter FirstNameParam = new SqlParameter("@FirstName", user.FirstName);
            command.Parameters.Add(FirstNameParam);

            SqlParameter LastNameParam = new SqlParameter("@LastName", user.LastName);
            command.Parameters.Add(LastNameParam);

            SqlParameter BDParam = new SqlParameter("@BirthDate", user.BirthDate);
            command.Parameters.Add(BDParam);

            SqlParameter LogParam = new SqlParameter("@Login", user.Login);
            command.Parameters.Add(LogParam);

            SqlParameter PassParam = new SqlParameter("@Password", user.Password);
            command.Parameters.Add(PassParam);

            SqlParameter EmailParam = new SqlParameter("@Email", user.Email);
            command.Parameters.Add(EmailParam);

            SqlParameter PhoneParam = new SqlParameter("@Phone", user.Phone);
            command.Parameters.Add(PhoneParam);

            return command.ExecuteNonQuery();
        }
        public int User_DeleteAccount(SqlConnection connection, UserDTO user)//удаление студента и всего, что с ним связано
        {
            connection.Open();
            string sqlExpression = "User_DeleteAccount";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter userParam = new SqlParameter("@UserID", user.ID);
            command.Parameters.Add(userParam);
            return command.ExecuteNonQuery();
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
