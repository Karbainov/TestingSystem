using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class AttemptByUserTest
    {
        public AttemptByUserTest()
        {
        }

        public List<AttemptResultDTO> AttemptGetByUserIdTestId(AttemptDTO attempt)
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "Attempt_GetByUserIdTestId";
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter userIdParam = new SqlParameter
            {
                ParameterName = "@userId",
                Value = attempt.userID
            };
            command.Parameters.Add(userIdParam);

            SqlParameter testIdParam = new SqlParameter
            {
                ParameterName = "@testId",
                Value = attempt.testID
            };
            command.Parameters.Add(testIdParam);

            var reader = command.ExecuteReader();
            List<AttemptResultDTO> attempts = new List<AttemptResultDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AttemptResultDTO at = new AttemptResultDTO();

                    at.number = reader.GetByte(0);
                    at.date = reader.GetDateTime(1);
                    at.result = reader.GetByte(2);
                    at.duration = reader.GetTimeSpan(3);
                    attempts.Add(at);
                }
            }
            reader.Close();
            return attempts;
        }
    }
}
