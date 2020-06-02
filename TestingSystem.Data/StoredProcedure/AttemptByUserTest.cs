using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class AttemptByUserTest
    {
        public AttemptByUserTest()
        {
        }
        
        public List<AttemptResultDTO> AttemptGetByUserIdTestId(UserIdTestIdForAttemptDTO attempt)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_GetByUserIdTestId";
            List<AttemptResultDTO> attempts = new List<AttemptResultDTO>();
            attempts = connection.Query<AttemptResultDTO>(sqlExpression, attempt, commandType: CommandType.StoredProcedure).ToList();
            return attempts;
        }
    }
}
