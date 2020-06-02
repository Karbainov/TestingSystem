using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    static class Test_Group
    {
        static public int Test_Group_Add(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_Add";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idGroupParam = new SqlParameter("@idGroup", test_group.idGroup);
            command.Parameters.Add(idGroupParam);

            SqlParameter idTestParam = new SqlParameter("@idTest", test_group.idTest);
            command.Parameters.Add(idTestParam);

            SqlParameter startDateParam = new SqlParameter("@startDate", test_group.startDate);
            command.Parameters.Add(startDateParam);

            SqlParameter endDate = new SqlParameter("@endDate", test_group.endDate);
            command.Parameters.Add(endDate);

            return command.ExecuteNonQuery();
        }

        static public int Test_Group_DeleteByGroupId(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_DeleteByGroupId";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idGroupParam = new SqlParameter("@idGroup", test_group.idGroup);
            command.Parameters.Add(idGroupParam);

            return command.ExecuteNonQuery();
        }

        static public int Test_Group_DeleteByGroupId_TestId(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_DeleteByGroupId_TestId";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idGroupParam = new SqlParameter("@idGroup", test_group.idGroup);
            command.Parameters.Add(idGroupParam);

            SqlParameter idTestParam = new SqlParameter("@idTest", test_group.idTest);
            command.Parameters.Add(idTestParam);

            return command.ExecuteNonQuery();
        }

        static public int Test_Group_DeleteById(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_DeleteById";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idTestGroupParam = new SqlParameter("@idTestsGroup", test_group.id);
            command.Parameters.Add(idTestGroupParam);

            return command.ExecuteNonQuery();
        }

        static public int Test_Group_DeleteByTestId(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_DeleteByTestId";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idTestParam = new SqlParameter("@idTest", test_group.idTest);
            command.Parameters.Add(idTestParam);

            return command.ExecuteNonQuery();
        }

        static public List<Test_GroupDTO> Test_Group_GetAll(SqlConnection connection)
        {
            connection.Open();
            string sqlExpression = "Test_Group_GetAll";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();

            List<Test_GroupDTO> test_groupAll = new List<Test_GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    Test_GroupDTO test_groupAll1 = new Test_GroupDTO();

                    test_groupAll1.id = (int)reader["ID"];
                    test_groupAll1.idGroup = (int)reader["GroupID"];
                    test_groupAll1.idTest = (int)reader["TestID"];
                    test_groupAll1.startDate = (DateTime)reader["StartDate"];
                    test_groupAll1.endDate = (DateTime)reader["EndDate"];
                    test_groupAll.Add(test_groupAll1);
                }
            }
            reader.Close();
            return test_groupAll;

        }

        static public List<Test_GroupDTO> Test_Group_GetByGroupId(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_GetByGroupId";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idGroupParam = new SqlParameter("@idGroup", test_group.idGroup);
            command.Parameters.Add(idGroupParam);

            SqlDataReader reader = command.ExecuteReader();

            List<Test_GroupDTO> test_group_GAll = new List<Test_GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    Test_GroupDTO test_group_GAll1 = new Test_GroupDTO();

                    test_group_GAll1.id = (int)reader["ID"];
                    test_group_GAll1.idGroup = (int)reader["GroupID"];
                    test_group_GAll1.idTest = (int)reader["TestID"];
                    test_group_GAll1.startDate = (DateTime)reader["StartDate"];
                    test_group_GAll1.endDate = (DateTime)reader["EndDate"];
                    test_group_GAll.Add(test_group_GAll1);
                }
            }
            reader.Close();
            return test_group_GAll;

        }

        static public List<Test_GroupDTO> Test_Group_GetByGroupId_TestId(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_GetByGroupId_TestId";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idGroupParam = new SqlParameter("@idGroup", test_group.idGroup);
            command.Parameters.Add(idGroupParam);

            SqlParameter idTestParam = new SqlParameter("@idTest", test_group.idTest);
            command.Parameters.Add(idTestParam);
            SqlDataReader reader = command.ExecuteReader();

            List<Test_GroupDTO> test_group_GId_TId = new List<Test_GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    Test_GroupDTO test_group_GId_TId1 = new Test_GroupDTO();

                    test_group_GId_TId1.id = (int)reader["ID"];
                    test_group_GId_TId1.idGroup = (int)reader["GroupID"];
                    test_group_GId_TId1.idTest = (int)reader["TestID"];
                    test_group_GId_TId1.startDate = (DateTime)reader["StartDate"];
                    test_group_GId_TId1.endDate = (DateTime)reader["EndDate"];
                    test_group_GId_TId.Add(test_group_GId_TId1);
                }
            }
            reader.Close();
            return test_group_GId_TId;
        }

        static public List<Test_GroupDTO> Test_Group_GetById(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_GetById";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idTestGroupParam = new SqlParameter("@idTestsGroup", test_group.id);
            command.Parameters.Add(idTestGroupParam);
            SqlDataReader reader = command.ExecuteReader();

            List<Test_GroupDTO> test_group_Id = new List<Test_GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    Test_GroupDTO test_group_Id1 = new Test_GroupDTO();

                    test_group_Id1.id = (int)reader["ID"];
                    test_group_Id1.idGroup = (int)reader["GroupID"];
                    test_group_Id1.idTest = (int)reader["TestID"];
                    test_group_Id1.startDate = (DateTime)reader["StartDate"];
                    test_group_Id1.endDate = (DateTime)reader["EndDate"];
                    test_group_Id.Add(test_group_Id1);
                }
            }
            reader.Close();
            return test_group_Id;
        }

        static public int Test_Group_Update(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_Update";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idTestGroupParam = new SqlParameter("@idTestsGroup", test_group.id);
            command.Parameters.Add(idTestGroupParam);

            SqlParameter idGroupParam = new SqlParameter("@idGroup", test_group.idGroup);
            command.Parameters.Add(idGroupParam);

            SqlParameter idTestParam = new SqlParameter("@idTest", test_group.idTest);
            command.Parameters.Add(idTestParam);

            SqlParameter startDateParam = new SqlParameter("@startDate", test_group.startDate);
            command.Parameters.Add(startDateParam);

            SqlParameter endDate = new SqlParameter("@endDate", test_group.endDate);
            command.Parameters.Add(endDate);

            return command.ExecuteNonQuery();
        }
    }
}
