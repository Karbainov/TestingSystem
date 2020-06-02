using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using TestingSystem.Data.DTO;
using Dapper;

namespace TestingSystem.Data.StoredProcedure
{
    public class StudentIncompleteTestsGetter
    {
        public List<TestWithStatsDTO> GetStudentIncompleteTests(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_GetIncompleteTests";
                return connection.Query<TestWithStatsDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
