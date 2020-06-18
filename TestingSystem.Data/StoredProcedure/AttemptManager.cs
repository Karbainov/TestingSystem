using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class AttemptManager
    {
        public List<AttemptResultDTO> GetAttemptByUserIdTestId(UserIdTestIdDTO attempt)
        {

            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "Attempt_GetByUserIdTestId";
                return connection.Query<AttemptResultDTO>(sqlExpression, attempt, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        
        public List<QuestionAnswerDTO> GetAllAnswersByAttemptId(int attemptId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetAllAnswersByAttemptId";
                connection.Execute(sqlExpression, new { attemptId }, commandType: CommandType.StoredProcedure);
                return connection.Query<QuestionAnswerDTO>(sqlExpression, attemptId, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        
        public List<AttemptResultDTO> GetBestResultsOfStudentsByTestId(int testId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetBestResultsOfStudentsByTestId";
                connection.Execute(sqlExpression, new { testId }, commandType: CommandType.StoredProcedure);
                return connection.Query<AttemptResultDTO>(sqlExpression, testId, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        
        public void UpdateResult(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Attempt_UpdateResult";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public int AddAttemptAutoNumber(AttemptDTO attempt)
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "AddAttemptAutoNumber @userID, @testID, @userResult, @dateTime, @durationTime";
                return connection.Query<int>(sqlExpression, attempt, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
