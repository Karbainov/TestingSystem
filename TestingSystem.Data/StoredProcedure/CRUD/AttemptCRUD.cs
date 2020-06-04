using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    public class AttemptCRUD
    {
        public AttemptCRUD()
        {

        }

        public int AttemptAdd(AttemptDTO attempt)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Add @number, @userID, @testID, @userResult, @dateTime, @durationTime";
            int attemptID = connection.Query<int>(sqlExpression, attempt).FirstOrDefault();
            attempt.id = attemptID;
            return attempt.id;
        }
        
        public List<AttemptDTO> AttemptGetAll()
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_GetALL";
            List<AttemptDTO> attempt = new List<AttemptDTO>();
            attempt = connection.Query<AttemptDTO>(sqlExpression).ToList();
            return attempt;
        }



        public List<AttemptDTO> AttemptByUserId(int userID)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_GetByUserID";
            
            return connection.Query<AttemptDTO>(sqlExpression, new { userID }, commandType: CommandType.StoredProcedure).ToList();
           
        }



        public List<AttemptDTO> AttemptByTestId(int testID)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_GetByTestID";
            return connection.Query<AttemptDTO>(sqlExpression, new { testID }, commandType: CommandType.StoredProcedure).ToList();
        }

        public void AttemptUpdate(AttemptDTO attempt)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Update";
            connection.Execute(sqlExpression, attempt, commandType: CommandType.StoredProcedure);
        }

        public void AttemptDelete(int id)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Delete";
            connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
