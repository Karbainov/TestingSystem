using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    class User_Role
    {
        public int User_Role_Create(SqlConnection connection, User_RoleDTO user_Role)
        {
            connection.Open();
            string sqlExpression = "User_Role_Create";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter roleParam = new SqlParameter("@RoleID", user_Role.RoleID);
            command.Parameters.Add(roleParam);
            SqlParameter userParam = new SqlParameter("@UserID", user_Role.UserID);
            command.Parameters.Add(userParam);
            return command.ExecuteNonQuery();
        }
        public int User_Role_Delete(SqlConnection connection, User_RoleDTO user_Role)
        {
            connection.Open();
            string sqlExpression = "User_Role_Delete";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter roleParam = new SqlParameter("@RoleID", user_Role.RoleID);
            command.Parameters.Add(roleParam);
            SqlParameter userParam = new SqlParameter("@UserID", user_Role.UserID);
            command.Parameters.Add(userParam);
            return command.ExecuteNonQuery();
        }
        public List<User_RoleDTO> User_Role_Read(SqlConnection connection)
        {
            connection.Open();
            string sqlExpression = "User_Role_Read";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            List<User_RoleDTO> user_roles = new List<User_RoleDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    User_RoleDTO role = new User_RoleDTO();

                    role.ID = (int)reader["id"];
                    role.RoleID = (int)reader["RoleID"];
                    role.UserID = (int)reader["UserID"];
                    user_roles.Add(role);
                }
            }
            reader.Close();
            return user_roles;
        }
        public List<User_RoleDTO> User_Role_ReadByUserID(SqlConnection connection, User_RoleDTO user_Role)
        {
            connection.Open();
            string sqlExpression = "User_Role_ReadByUserID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter userParam = new SqlParameter("@UserID", user_Role.UserID);
            command.Parameters.Add(userParam);
            SqlDataReader reader = command.ExecuteReader();
            List<User_RoleDTO> user_roles = new List<User_RoleDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    User_RoleDTO role = new User_RoleDTO();

                    role.ID = (int)reader["id"];
                    role.RoleID = (int)reader["RoleID"];
                    role.UserID = (int)reader["UserID"];
                    user_roles.Add(role);
                }
            }
            reader.Close();
            return user_roles;
        }
        public List<User_RoleDTO> User_Role_ReadByRoleID(SqlConnection connection, User_RoleDTO user_Role)
        {
            connection.Open();
            string sqlExpression = "User_Role_ReadByRoleID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter roleParam = new SqlParameter("@RoleID", user_Role.RoleID);
            command.Parameters.Add(roleParam);
            SqlDataReader reader = command.ExecuteReader();
            List<User_RoleDTO> user_roles = new List<User_RoleDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    User_RoleDTO role = new User_RoleDTO();

                    role.ID = (int)reader["id"];
                    role.RoleID = (int)reader["RoleID"];
                    role.UserID = (int)reader["UserID"];
                    user_roles.Add(role);
                }
            }
            reader.Close();
            return user_roles;
        }
    }
}
