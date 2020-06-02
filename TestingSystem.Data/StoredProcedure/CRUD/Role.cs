using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    class Role
    {
        public int Role_Create(SqlConnection connection, RoleDTO role)
        {
            connection.Open();
            string sqlExpression = "Role_Create";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter nameParam = new SqlParameter("@Name", role.Name);
            command.Parameters.Add(nameParam);
            return command.ExecuteNonQuery();
        }
        public int Role_Delete(SqlConnection connection, RoleDTO role)
        {
            connection.Open();
            string sqlExpression = "Role_Delete";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idParam = new SqlParameter("@ID", role.ID);
            command.Parameters.Add(idParam);
            return command.ExecuteNonQuery();
        }
        public int Role_Update(SqlConnection connection, RoleDTO role)
        {
            connection.Open();
            string sqlExpression = "Role_Update";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idParam = new SqlParameter("@ID", role.ID);
            command.Parameters.Add(idParam);
            SqlParameter nameParam = new SqlParameter("@Name", role.Name);
            command.Parameters.Add(nameParam);
            return command.ExecuteNonQuery();
        }
        public List<RoleDTO> Role_Read(SqlConnection connection)
        {
            connection.Open();
            string sqlExpression = "Role_Read";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            List<RoleDTO> roles = new List<RoleDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    RoleDTO role = new RoleDTO();

                    role.ID = (int)reader["id"];
                    role.Name = (string)reader["Name"];
                    roles.Add(role);
                }
            }
            reader.Close();

            return roles;
        }
        public List<RoleDTO> Role_ReadById(SqlConnection connection, RoleDTO role)
        {
            connection.Open();
            string sqlExpression = "Role_ReadById";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter idParam = new SqlParameter("@ID", role.ID);
            command.Parameters.Add(idParam);
            SqlDataReader reader = command.ExecuteReader();
            List<RoleDTO> roles = new List<RoleDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    RoleDTO newRole = new RoleDTO();

                    //role.ID = (int)reader["ID"];
                    role.Name = (string)reader["Name"];
                    roles.Add(role);
                }
            }
            reader.Close();

            return roles;
        }
    }
}
