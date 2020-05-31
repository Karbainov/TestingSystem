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

        static public int Test_Group_GetAll(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_GetAll";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command.ExecuteNonQuery();
        }

        static public int Test_Group_GetByGroupId(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_GetByGroupId";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idGroupParam = new SqlParameter("@idGroup", test_group.idGroup);
            command.Parameters.Add(idGroupParam);

            return command.ExecuteNonQuery();
        }

        static public int Test_Group_GetByGroupId_TestId(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_GetByGroupId_TestId";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idGroupParam = new SqlParameter("@idGroup", test_group.idGroup);
            command.Parameters.Add(idGroupParam);

            SqlParameter idTestParam = new SqlParameter("@idTest", test_group.idTest);
            command.Parameters.Add(idTestParam);

            return command.ExecuteNonQuery();
        }

        static public int Test_Group_GetById(SqlConnection connection, Test_GroupDTO test_group)
        {
            connection.Open();
            string sqlExpression = "Test_Group_GetById";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idTestGroupParam = new SqlParameter("@idTestsGroup", test_group.id);
            command.Parameters.Add(idTestGroupParam);

            return command.ExecuteNonQuery();
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
