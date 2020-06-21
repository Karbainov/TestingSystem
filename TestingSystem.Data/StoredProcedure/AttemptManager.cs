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
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_GetByUserIdTestId";
            return connection.Query<AttemptResultDTO>(sqlExpression, attempt, commandType: CommandType.StoredProcedure).ToList();
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

        public int AddAttemptForAttemptCreator(int userId, int testId)
        {
            AttemptDTO attempt = new AttemptDTO()
            {
                userID = userId,
                testID = testId,
                dateTime = DateTime.Now

            };
            AttemptManager student = new AttemptManager();
            return student.AddAttemptAutoNumber(attempt);
        }

        public void AddQuestionToAttempt(int attemptID, int questionId)
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "AddQuestionToAttempt @attemptID, @questionId";
                connection.Execute(sqlExpression, new { attemptID, questionId }, commandType: CommandType.StoredProcedure);
            }
        }

              
    }
}
