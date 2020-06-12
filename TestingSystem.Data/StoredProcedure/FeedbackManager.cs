
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
        

        public List<FeedbackDTO> GetFeedbackByDate(DateTime dateTime1, DateTime dateTime2)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetFeedbackByDateTime";
                return connection.Query<FeedbackDTO>(sqlExpression, new { dateTime1, dateTime2 }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<FeedbackDTO> GetFeedbackByTest(int testId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "GetTestFeedback";            
            return connection.Query<FeedbackDTO>(sqlExpression, testId, commandType: CommandType.StoredProcedure).ToList();            
        }

        public List<FeedbackDTO> GetProcessedFeedback()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Feedback_processed";
                return connection.Query<FeedbackDTO>(sqlExpression, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<FeedbackDTO> GetNotProcessedFeedback()
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Feedback_NotProcessed";
            return connection.Query<FeedbackDTO>(sqlExpression, commandType: CommandType.StoredProcedure).ToList();            
        }

        public int UpdateProcessedInFeedback(int id)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Feedback_UpdateProcessed";
            connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            return id;
        }
    }
}
