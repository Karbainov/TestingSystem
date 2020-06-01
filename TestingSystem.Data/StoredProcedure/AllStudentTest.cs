using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class AllStudentTest
    {
        static public List<AllStudentTestsDTO> AllStudentTests(SqlConnection connection, AllStudentTestsDTO allStudent)
        {
            connection.Open();
            string sqlExpression = "AllStudentTests";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter userIdParam = new SqlParameter("@UserId", allStudent.userId);
            command.Parameters.Add(userIdParam);

            SqlDataReader reader = command.ExecuteReader();

            List<AllStudentTestsDTO> allStudentTest = new List<AllStudentTestsDTO>();

            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    AllStudentTestsDTO allStudentTest1 = new AllStudentTestsDTO();

                    allStudentTest1.userId = (int)reader["ID"];
                    allStudentTest1.firstName = (string)reader["FirstName"];
                    allStudentTest1.lastName = (string)reader["LastName"];
                    allStudentTest1.nameTest = (string)reader["NameTest"];
                    allStudentTest1.numberOfAttempts = (int)reader["NumberOfAttempts"];
                    allStudentTest1.maxResult = (int)reader["MaxResult"];

                    allStudentTest.Add(allStudentTest1);
                }
            }
            reader.Close();

            return allStudentTest;
        }
    }
}
