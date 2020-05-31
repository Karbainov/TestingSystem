using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public static class SearchTestByTag
    {
        static public int SearchTestByTagOr(SqlConnection connection, SearchTestByTagDTO search)
        {
            connection.Open();
            string sqlExpression = "SearchTestByTagOr";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter tag1Param = new SqlParameter("@tag1", search.tag1);
            command.Parameters.Add(tag1Param);

            SqlParameter tag2Param = new SqlParameter("@tag2", search.tag2);
            command.Parameters.Add(tag2Param);

            SqlParameter tag3Param = new SqlParameter("@tag3", search.tag3);
            command.Parameters.Add(tag3Param);

            return command.ExecuteNonQuery();
        }

        static public int SearchTestByTagAnd(SqlConnection connection, SearchTestByTagDTO search)
        {
            connection.Open();
            string sqlExpression = "SearchTestByTagAnd";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter tag1Param = new SqlParameter("@tag1", search.tag1);
            command.Parameters.Add(tag1Param);

            SqlParameter tag2Param = new SqlParameter("@tag2", search.tag2);
            command.Parameters.Add(tag2Param);

            SqlParameter tag3Param = new SqlParameter("@tag3", search.tag3);
            command.Parameters.Add(tag3Param);

            return command.ExecuteNonQuery();
        }
    }
}
