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

        public List<FeedbackQuestionDTO> FBQuestionGetByUserId(FeedbackDTO feedback)
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
            List<FeedbackQuestionDTO> feedbacks = new List<FeedbackQuestionDTO>();

            if (reader.HasRows)
            {                
                while (reader.Read())
                {
                    FeedbackQuestionDTO fb = new FeedbackQuestionDTO();
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
