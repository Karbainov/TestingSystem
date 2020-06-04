using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TestingSystem.Data.StoredProcedure
{
    public class QuestionManager
    {
        public void DeleteQuestionFromTest(int questionId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Question_DeleteFromTest";
            connection.Execute(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure);
        }
    }
}
