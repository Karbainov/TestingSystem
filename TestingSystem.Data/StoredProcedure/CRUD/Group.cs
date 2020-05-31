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

        static public List<GroupDTO> Group_GetAll(SqlConnection connection)
        {
            connection.Open();
            string sqlExpression = "Group_GetAll";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            List<GroupDTO> groupAll = new List<GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    GroupDTO groupAll1 = new GroupDTO();

                    groupAll1.id = (int)reader["ID"];
                    groupAll1.name = (string)reader["Name"];
                    groupAll1.startDate = (DateTime)reader["StartDate"];
                    groupAll1.endDate = (DateTime)reader["EndDate"];
                    groupAll.Add(groupAll1);
                }
            }
            reader.Close();
            return groupAll;

        }


        static public List<GroupDTO> Group_GetById(SqlConnection connection, GroupDTO group)
        {
            connection.Open();
            string sqlExpression = "Group_GetById";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idParam = new SqlParameter("@idGroup", group.id);
            command.Parameters.Add(idParam);
            SqlDataReader reader = command.ExecuteReader();

            List<GroupDTO> group_GetById = new List<GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    GroupDTO group_GetById1 = new GroupDTO();

                    group_GetById1.id = (int)reader["ID"];
                    group_GetById1.name = (string)reader["Name"];
                    group_GetById1.startDate = (DateTime)reader["StartDate"];
                    group_GetById1.endDate = (DateTime)reader["EndDate"];
                    group_GetById.Add(group_GetById1);
                }
            }
            reader.Close();
            return group_GetById;
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
