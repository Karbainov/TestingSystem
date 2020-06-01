using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    class Question_DeleteFromTests
    {
        static public int Question_DeleteFromTest(SqlConnection connection, Question_DeleteFromTestDTO question_Del_Test)
        {
            connection.Open();
            string sqlExpression = "Question_DeleteFromTest";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter questionIdParam = new SqlParameter("@questionId", question_Del_Test.questionId);
            command.Parameters.Add(questionIdParam);

            SqlParameter testIdParam = new SqlParameter("@testId", question_Del_Test.testId);
            command.Parameters.Add(testIdParam);

            return command.ExecuteNonQuery();
        }
    }
}
