using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    static class Group
    {
        static public int Group_Add(SqlConnection connection, GroupDTO group)
        {
            connection.Open();
            string sqlExpression = "Group_Add";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter nameParam = new SqlParameter("@name", group.name);
            command.Parameters.Add(nameParam);

            SqlParameter startDateParam = new SqlParameter("@startDate", group.startDate);
            command.Parameters.Add(startDateParam);

            SqlParameter endDate = new SqlParameter("@endDate", group.endDate);
            command.Parameters.Add(endDate);

            return command.ExecuteNonQuery();
        }

        static public int Group_Delete(SqlConnection connection, GroupDTO group)
        {
            connection.Open();
            string sqlExpression = "Group_Delete";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idParam = new SqlParameter("@idGroup", group.id);
            command.Parameters.Add(idParam);

            return command.ExecuteNonQuery();
        }

        static public int Group_GetAll(SqlConnection connection, GroupDTO group)
        {
            connection.Open();
            string sqlExpression = "Group_GetAll";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command.ExecuteNonQuery();
        }


        static public int Group_GetById(SqlConnection connection, GroupDTO group)
        {
            connection.Open();
            string sqlExpression = "Group_GetById";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idParam = new SqlParameter("@idGroup", group.id);
            command.Parameters.Add(idParam);

            return command.ExecuteNonQuery();
        }

        static public int Group_Update(SqlConnection connection, GroupDTO group)
        {
            connection.Open();
            string sqlExpression = "Group_Update";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idParam = new SqlParameter("@idGroup", group.id);
            command.Parameters.Add(idParam);

            SqlParameter nameParam = new SqlParameter("@name", group.name);
            command.Parameters.Add(nameParam);

            SqlParameter startDateParam = new SqlParameter("@startDate", group.startDate);
            command.Parameters.Add(startDateParam);

            SqlParameter endDate = new SqlParameter("@endDate", group.endDate);
            command.Parameters.Add(endDate);

            return command.ExecuteNonQuery();
        }
    }
}
