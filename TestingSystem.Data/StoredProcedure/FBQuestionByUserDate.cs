using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class FBQuestionByUserDate
    {
        public FBQuestionByUserDate()
        {
        }

        public List<FBQuestionByUserDateDTO> FBQuestionGetByUserId(FBQuestionByUserDateDTO feedback)
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "FeedBackQuestion_GetByUserDate";
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter userIdParam = new SqlParameter
            {
                ParameterName = "@userId",
                Value = feedback.userId
            };
            command.Parameters.Add(userIdParam);

            SqlParameter dateParam = new SqlParameter
            {
                ParameterName = "@date",
                Value = feedback.date
            };
            command.Parameters.Add(dateParam);

            var reader = command.ExecuteReader();
            List<FBQuestionByUserDateDTO> feedbacks = new List<FBQuestionByUserDateDTO>();

            if (reader.HasRows)
            {                
                while (reader.Read())
                {
                    FBQuestionByUserDateDTO fb = new FBQuestionByUserDateDTO();
                    fb.message = reader.GetString(0);
                    fb.value = reader.GetString(1);
                    feedbacks.Add(fb);
                }
            }
            reader.Close();
            return feedbacks;
        }
    }
}
