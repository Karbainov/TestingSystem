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
        public int Add(AttemptDTO attempt)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Add @number, @userID, @testID, @userResult, @dateTime, @durationTime";
            return connection.Query<int>(sqlExpression, attempt).FirstOrDefault();
        }
        
        public List<AttemptDTO> GetAll()
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_GetALL";
            return connection.Query<AttemptDTO>(sqlExpression).ToList();
        }



        public List<AttemptDTO> GetByUserId(int userId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_GetByUserID";
            
            return connection.Query<AttemptDTO>(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure).ToList();
           
        }



        public List<AttemptDTO> GetByTestId(int testId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_GetByTestID";
            return connection.Query<AttemptDTO>(sqlExpression, new { testId }, commandType: CommandType.StoredProcedure).ToList();
        }

        public void Update(AttemptDTO attempt)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Update";
            connection.Execute(sqlExpression, attempt, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Delete";
            connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
