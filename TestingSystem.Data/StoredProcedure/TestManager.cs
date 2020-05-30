using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    class TestManager
    {
        public List<TestDTO> Test_Attempt_GetLate(SqlConnection connection, UserDTO user)//просроченные тесты студента
        {

            connection.Open();
            string sqlExpression = "Test_Attempt_GetLate";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter idParam = new SqlParameter("@UserID", user.ID);
            command.Parameters.Add(idParam);
            SqlDataReader reader = command.ExecuteReader();

            List<TestDTO> test = new List<TestDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    TestDTO test1 = new TestDTO();

                    test1.ID = (int)reader["id"];
                    test1.Name = (string)reader["Name"];
                    test1.DurationTime = (DateTime)reader["DurationTime"];
                    test1.SuccessScore = (int)reader["SuccessScore"];
                    test.Add(test1);
                }
            }
            reader.Close();
            return test;
        }
    }
}
