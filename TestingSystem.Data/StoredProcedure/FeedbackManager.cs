{
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TestingSystem.Data.DTO;
using Dapper;
using System.Linq;

namespace TestingSystem.Data.StoredProcedure
{
    public class FeedbackManager
    {
        

        public List<FeedbackByDateDTO> GetFeedbackByDate(DateTime dateTime1, DateTime dateTime2)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetFeedbackByDateTime";
                return connection.Query<FeedbackByDateDTO>(sqlExpression, new { dateTime1, dateTime2 }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<FeedbackByTestIDDTO> GetFeedbackByTest(FeedbackByTestIDDTO feedback)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "GetTestFeedback";
            List<FeedbackByTestIDDTO> fb = new List<FeedbackByTestIDDTO>();
            fb = connection.Query<FeedbackByTestIDDTO>(sqlExpression, feedback, commandType: CommandType.StoredProcedure).ToList();
            return fb;
        }

        public List<FeedbackDTO> FeedbackProcessed()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Feedback_processed";
                return connection.Query<FeedbackDTO>(sqlExpression, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
