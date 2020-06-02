using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class QuestionDeleteFromTests
    {
        public void QuestionDelete(int questionId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Question_DeleteFromTest";
            connection.Execute(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure);
        }
    }
}
