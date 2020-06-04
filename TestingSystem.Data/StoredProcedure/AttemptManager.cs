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

        public void UpdateResult(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Attempt_UpdateResult";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
