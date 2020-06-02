using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public static class SearchTestByTag
    {
        static public List<SearchTestByTagDTO> SearchTestByTagOr(SqlConnection connection, SearchTestByTagDTO search)
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

            SqlDataReader reader = command.ExecuteReader();

            List<SearchTestByTagDTO> searchOr = new List<SearchTestByTagDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    SearchTestByTagDTO searchOr1 = new SearchTestByTagDTO();

                    searchOr1.id = (int)reader["ID"];
                    searchOr1.name = (string)reader["Name"];
                    searchOr1.durationTime = (DateTime)reader["DurationTime"];
                    searchOr.Add(searchOr1);
                }
            }
            reader.Close();
            return searchOr;
        }

        static public List<SearchTestByTagDTO> SearchTestByTagAnd(SqlConnection connection, SearchTestByTagDTO search)
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

            SqlDataReader reader = command.ExecuteReader();

            List<SearchTestByTagDTO> searchAnd = new List<SearchTestByTagDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    SearchTestByTagDTO searchAnd1 = new SearchTestByTagDTO();

                    searchAnd1.id = (int)reader["ID"];
                    searchAnd1.name = (string)reader["Name"];
                    searchAnd1.durationTime = (DateTime)reader["DurationTime"];
                    searchAnd.Add(searchAnd1);
                }
            }
            reader.Close();
            return searchAnd;
        }
    }
}
