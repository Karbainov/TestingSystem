using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    class Teacher_Group
    {
        public int Teacher_Group_Add(SqlConnection connection, Teacher_GroupDTO teacher_Group)
        {
            connection.Open();
            string sqlExpression = "Teacher_Group_Add";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter groupParam = new SqlParameter("@GroupID", teacher_Group.GroupID);
            command.Parameters.Add(groupParam);
            SqlParameter userParam = new SqlParameter("@UserID", teacher_Group.UserID);
            command.Parameters.Add(userParam);
            return command.ExecuteNonQuery();
        }

        public List<Teacher_GroupDTO> Teacher_Group_GetAll(SqlConnection connection)
        {
            connection.Open();
            string sqlExpression = "Teacher_Group_GetAll";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            List<Teacher_GroupDTO> teacher_group = new List<Teacher_GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    Teacher_GroupDTO group = new Teacher_GroupDTO();

                    group.ID = (int)reader["id"];
                    group.GroupID = (int)reader["GroupID"];
                    group.UserID = (int)reader["UserID"];
                    teacher_group.Add(group);
                }
            }
            reader.Close();
            return teacher_group;
        }
        public List<Teacher_GroupDTO> Teacher_Group_GetByUserID(SqlConnection connection, Teacher_GroupDTO teacher_Group)
        {
            connection.Open();
            string sqlExpression = "Student_Group_GetByUserID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter userParam = new SqlParameter("@UserID", teacher_Group.UserID);
            command.Parameters.Add(userParam);
            SqlDataReader reader = command.ExecuteReader();
            List<Teacher_GroupDTO> teacher_group = new List<Teacher_GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    Teacher_GroupDTO group = new Teacher_GroupDTO();

                    group.ID = (int)reader["id"];
                    group.GroupID = (int)reader["GroupID"];
                    group.UserID = (int)reader["UserID"];
                    teacher_group.Add(group);
                }
            }
            reader.Close();
            return teacher_group;
        }
        public List<Teacher_GroupDTO> Teacher_Group_GetByGroupID(SqlConnection connection, Teacher_GroupDTO teacher_Group)
        {
            connection.Open();
            string sqlExpression = "Teacher_Group_GetByGroupID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter groupParam = new SqlParameter("@GroupID", teacher_Group.GroupID);
            command.Parameters.Add(groupParam);
            SqlDataReader reader = command.ExecuteReader();
            List<Teacher_GroupDTO> teacher_group = new List<Teacher_GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    Teacher_GroupDTO group = new Teacher_GroupDTO();

                    group.ID = (int)reader["id"];
                    group.GroupID = (int)reader["GroupID"];
                    group.UserID = (int)reader["UserID"];
                    teacher_group.Add(group);
                }
            }
            reader.Close();
            return teacher_group;
        }
        public int Teacher_Group_DeleteByID(SqlConnection connection, Teacher_GroupDTO teacher_Group)
        {
            connection.Open();
            string sqlExpression = "Teacher_Group_DeleteByID";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idParam = new SqlParameter("@ID", teacher_Group.ID);
            command.Parameters.Add(idParam);

            return command.ExecuteNonQuery();
        }
        public int Teacher_Group_DeleteByGroupID(SqlConnection connection, Teacher_GroupDTO teacher_Group)
        {
            connection.Open();
            string sqlExpression = "Teacher_Group_DeleteByGroupID";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter groupParam = new SqlParameter("@GroupID", teacher_Group.GroupID);
            command.Parameters.Add(groupParam);

            return command.ExecuteNonQuery();
        }
        public int Teacher_Group_DeleteByUserID(SqlConnection connection, Teacher_GroupDTO teacher_Group)
        {
            connection.Open();
            string sqlExpression = "Teacher_Group_DeleteByUserID";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter userParam = new SqlParameter("@UserID", teacher_Group.UserID);
            command.Parameters.Add(userParam);

            return command.ExecuteNonQuery();
        }
    }
}
