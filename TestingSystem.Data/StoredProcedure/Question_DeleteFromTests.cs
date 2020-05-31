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
            string sqlExpression = "Test_Group_Add";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter questionIdParam = new SqlParameter("@idGroup", question_Del_Test.questionId);
            command.Parameters.Add(questionIdParam);

            SqlParameter testIdParam = new SqlParameter("@idTest", question_Del_Test.testId);
            command.Parameters.Add(testIdParam);

            return command.ExecuteNonQuery();
        }
    }
}
