using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    public class Test
    {
        public Test()
        {

        }

        public void TestCreate(TestDTO test)
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "Test_Add";
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter nameParam = new SqlParameter
            {
                ParameterName = "@name",
                Value = test.name
            };
            command.Parameters.Add(nameParam);

            SqlParameter durationParam = new SqlParameter
            {
                ParameterName = "@duration",
                Value = test.duration
            };
            command.Parameters.Add(durationParam);

            SqlParameter scoreParam = new SqlParameter
            {
                ParameterName = "@score",
                Value = test.score
            };
            command.Parameters.Add(scoreParam);

            command.ExecuteNonQuery();
        }

        public List<TestDTO> TestRead()
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "Test_GetAll";
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            var reader = command.ExecuteReader();
            List<TestDTO> tests = new List<TestDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestDTO test = new TestDTO();

                    test.Id = reader.GetInt32(0);
                    test.name = reader.GetString(1);
                    test.duration = reader.GetTimeSpan(2);
                    test.score = reader.GetByte(3);
                    tests.Add(test);
                }
            }
            reader.Close();
            return tests;
        }

        public List<TestDTO> TestReadById(TestDTO test)
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "Test_GetById";
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IdParam = new SqlParameter
            {
                ParameterName = "@Id",
                Value = test.Id
            };
            command.Parameters.Add(IdParam);

            var reader = command.ExecuteReader();
            List<TestDTO> tests = new List<TestDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {                    
                    test.name = reader.GetString(1);
                    test.duration = reader.GetTimeSpan(2);
                    test.score = reader.GetByte(3);
                    tests.Add(test);
                }
            }
            reader.Close();
            return tests;
        }

        public void TestUpdate(TestDTO test)
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "Test_Update";
            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IdParam = new SqlParameter
            {
                ParameterName = "@Id",
                Value = test.Id
            };
            command.Parameters.Add(IdParam);

            SqlParameter nameParam = new SqlParameter
            {
                ParameterName = "@name",
                Value = test.name
            };
            command.Parameters.Add(nameParam);

            SqlParameter durationParam = new SqlParameter
            {
                ParameterName = "@duration",
                Value = test.duration
            };
            command.Parameters.Add(durationParam);

            SqlParameter scoreParam = new SqlParameter
            {
                ParameterName = "@score",
                Value = test.score
            };
            command.Parameters.Add(scoreParam);

            command.ExecuteNonQuery();
        }

        public void TestDelete(TestDTO test)
        {
            var connection = Connection.GetConnection();
            connection.Open();

            string sqlExpression = "Test_Delete";

            SqlCommand command = new SqlCommand(sqlExpression, connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IdParam = new SqlParameter
            {
                ParameterName = "@Id",
                Value = test.Id
            };
            command.Parameters.Add(IdParam);

            command.ExecuteNonQuery();
        }
    }
}
}
