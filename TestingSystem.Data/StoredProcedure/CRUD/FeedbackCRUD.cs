using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TestingSystem.Data.DTO;


namespace TestingSystem.Data.StoredProcedure.CRUD
{
    class FeedbackCRUD
    {
        public int FeedbackAdd(FeedbackDTO feedback)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Feedback_Create";

                return connection.Query<int>(sqlExpression, feedback).FirstOrDefault();
            }
        }

        public List<FeedbackDTO> FeedbackGetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Feedback_getAll";

                return connection.Query<FeedbackDTO>(sqlExpression).ToList();
            }
        }

        public FeedbackDTO FeedbackGetByID(int id)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Feedback_getId";            
            return connection.Query<FeedbackDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();            
        }

        public void FeedbackUpdate (FeedbackDTO feedback)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Feedback_updateAll";

               connection.Query<int>(sqlExpression, feedback);
            }
        }

        public void FeedbackDelete(FeedbackDTO feedback)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Feedback_delete @ID";

                connection.Query<int>(sqlExpression, feedback.ID);
            }
        }
    }
}
