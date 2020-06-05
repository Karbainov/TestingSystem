using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    class User
    {
        public int User_Create(SqlConnection connection, UserDTO user)
        {
            connection.Open();
            string sqlExpression = "User_Create";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;



            SqlParameter FirstNameParam = new SqlParameter("@FirstName", user.FirstName);
            command.Parameters.Add(FirstNameParam);

            SqlParameter LastNameParam = new SqlParameter("@LastName", user.LastName);
            command.Parameters.Add(LastNameParam);

            SqlParameter BDParam = new SqlParameter("@BirthDate", user.BirthDate);
            command.Parameters.Add(BDParam);

            SqlParameter LogParam = new SqlParameter("@Login", user.Login);
            command.Parameters.Add(LogParam);

            SqlParameter PassParam = new SqlParameter("@Login", user.Password);
            command.Parameters.Add(PassParam);

            SqlParameter EmailParam = new SqlParameter("@Email", user.Email);
            command.Parameters.Add(EmailParam);

            SqlParameter PhoneParam = new SqlParameter("@Phone", user.Phone);
            command.Parameters.Add(PhoneParam);

            return command.ExecuteNonQuery();
        }
        public int User_Update(SqlConnection connection, UserDTO user)
        {
            connection.Open();
            string sqlExpression = "User_Update";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;



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
    }
}
