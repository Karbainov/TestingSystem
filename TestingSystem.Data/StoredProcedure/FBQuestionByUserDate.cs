﻿using System;
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

        public List<FeedbackQuestionDBO> FBQuestionGetByUserId(FeedbackDTO feedback)
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
            List<FeedbackQuestionDBO> feedbacks = new List<FeedbackQuestionDBO>();

            if (reader.HasRows)
            {                
                while (reader.Read())
                {
                    FeedbackQuestionDBO fb = new FeedbackQuestionDBO();
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
