
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    public class Attempt
    {
        public Attempt()
        {

        }

        public void AttemptCreate(AttemptDTO Attempt)
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "Attempt_Add";
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@id",
                Value = Attempt.id
            };
            command.Parameters.Add(idParam);

            SqlParameter numberParam = new SqlParameter
            {
                ParameterName = "@number",
                Value = Attempt.number
            };
            command.Parameters.Add(numberParam);


            SqlParameter userIDParam = new SqlParameter
            {
                ParameterName = "@userID",
                Value = Attempt.userID
            };
            command.Parameters.Add(userIDParam);

            SqlParameter testIDParam = new SqlParameter
            {
                ParameterName = "@testID",
                Value = Attempt.testID
            };
            command.Parameters.Add(testIDParam);

            SqlParameter userResultParam = new SqlParameter
            {
                ParameterName = "@userResult",
                Value = Attempt.userResult
            };
            command.Parameters.Add(userResultParam);

            SqlParameter dateTimeParam = new SqlParameter
            {
                ParameterName = "@dateTime",
                Value = Attempt.dateTime
            };
            command.Parameters.Add(dateTimeParam);

            SqlParameter durationTimeParam = new SqlParameter
            {
                ParameterName = "@durationTime",
                Value = Attempt.durationTime
            };
            command.Parameters.Add(durationTimeParam);

            command.ExecuteNonQuery();
        }

        public List<AttemptDTO> AttemptRead()
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "Attempt_GetAll";
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            var reader = command.ExecuteReader();

            List<AttemptDTO> attempts = new List<AttemptDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AttemptDTO attempt = new AttemptDTO();

                    attempt.id = reader.GetInt32(0);
                    attempt.number = reader.GetInt32(1);
                    attempt.userID = reader.GetInt32(2);
                    attempt.testID = reader.GetInt32(3);
                    attempt.userResult = reader.GetInt32(4);
                    attempt.dateTime = reader.GetDateTime(5);
                    attempt.durationTime = reader.GetTimeSpan(6);
                    attempts.Add(attempt);
                }
            }
            reader.Close();
            return attempts;
        }



        public List<AttemptDTO> AttemptByUserId(AttemptDTO attempt)
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "Attempt_GetByUserID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter userIDParam = new SqlParameter
            {
                ParameterName = "@userID",
                Value = attempt.userID
            };
            command.Parameters.Add(userIDParam);

            var reader = command.ExecuteReader();


            List<AttemptDTO> attempts = new List<AttemptDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    attempt.id = reader.GetInt32(1);
                    attempt.number = reader.GetInt32(2);
                    attempt.testID = reader.GetInt32(3);
                    attempt.userResult = reader.GetInt32(4);
                    attempt.dateTime = reader.GetDateTime(5);
                    attempt.durationTime = reader.GetTimeSpan(6);
                    attempts.Add(attempt);
                }
            }

            reader.Close();
            return attempts;
        }



        public List<AttemptDTO> AttemptByTestId(AttemptDTO attempt)
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "Attempt_GetByTestID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter testIDParam = new SqlParameter
            {
                ParameterName = "@testID",
                Value = attempt.userID
            };
            command.Parameters.Add(testIDParam);

            var reader = command.ExecuteReader();


            List<AttemptDTO> attempts = new List<AttemptDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    attempt.id = reader.GetInt32(1);
                    attempt.number = reader.GetInt32(2);
                    attempt.userID = reader.GetInt32(3);
                    attempt.userResult = reader.GetInt32(4);
                    attempt.dateTime = reader.GetDateTime(5);
                    attempt.durationTime = reader.GetTimeSpan(6);
                    attempts.Add(attempt);
                }
            }

            reader.Close();
            return attempts;
        }

        public void AttemptUpdate(AttemptDTO attempt)
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "Attempt_Update";
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@id",
                Value = attempt.id
            };
            command.Parameters.Add(idParam);

            SqlParameter numberParam = new SqlParameter
            {
                ParameterName = "@number",
                Value = attempt.number
            };
            command.Parameters.Add(numberParam);


            SqlParameter userIDParam = new SqlParameter
            {
                ParameterName = "@userID",
                Value = attempt.userID
            };
            command.Parameters.Add(userIDParam);

            SqlParameter testIDParam = new SqlParameter
            {
                ParameterName = "@testID",
                Value = attempt.testID
            };
            command.Parameters.Add(testIDParam);

            SqlParameter userResultParam = new SqlParameter
            {
                ParameterName = "@userResult",
                Value = attempt.userResult
            };
            command.Parameters.Add(userResultParam);

            SqlParameter dateTimeParam = new SqlParameter
            {
                ParameterName = "@dateTime",
                Value = attempt.dateTime
            };
            command.Parameters.Add(dateTimeParam);

            SqlParameter durationTimeParam = new SqlParameter
            {
                ParameterName = "@durationTime",
                Value = attempt.durationTime
            };
            command.Parameters.Add(durationTimeParam);

            command.ExecuteNonQuery();

        }

        public void AttemptDelete(AttemptDTO attempt)
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "Attempt_Delete";

            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@id",
                Value = attempt.id
            };
            command.Parameters.Add(idParam);

            command.ExecuteNonQuery();
        }
    }
}
