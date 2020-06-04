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
    public class QuestionManager
    {
        public void DeleteQuestionFromTest(int questionId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Question_DeleteFromTest";
            connection.Execute(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure);
        }

        public List<QuestionDTO> GetQuestionsByTestID(int TestID)
        {
            using (IDbConnection connection = Connection.GetConnection()) 
            { 
                string sqlExpression = "GetQuestionsByTestID";
                return connection.Query<QuestionDTO>(sqlExpression, new { TestID }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        
        public void CountQtyOfCorrectAnswer(int questionId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "CountQtyCorrectAnswers";
            connection.Execute(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure);
        }
    }
}
