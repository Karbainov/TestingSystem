using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    class Student_Group
    {
        public int Student_Group_Add(SqlConnection connection, Student_GroupDTO student_Group)
        {
            connection.Open();
            string sqlExpression = "Student_Group_Add";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter groupParam = new SqlParameter("@GroupID", student_Group.GroupID);
            command.Parameters.Add(groupParam);
            SqlParameter userParam = new SqlParameter("@UserID", student_Group.UserID);
            command.Parameters.Add(userParam);
            return command.ExecuteNonQuery();
        }

        public List<Student_GroupDTO> Student_Group_GetAll(SqlConnection connection)
        {
            connection.Open();
            string sqlExpression = "Student_Group_GetAll";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            List<Student_GroupDTO> student_group = new List<Student_GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    Student_GroupDTO group = new Student_GroupDTO();

                    group.ID = (int)reader["id"];
                    group.GroupID = (int)reader["GroupID"];
                    group.UserID = (int)reader["UserID"];
                    student_group.Add(group);
                }
            }
            reader.Close();
            return student_group;
        }
        public List<Student_GroupDTO> Student_Group_GetByUserID(SqlConnection connection, Student_GroupDTO student_Group)
        {
            connection.Open();
            string sqlExpression = "Student_Group_GetByUserID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter userParam = new SqlParameter("@UserID", student_Group.UserID);
            command.Parameters.Add(userParam);
            SqlDataReader reader = command.ExecuteReader();
            List<Student_GroupDTO> student_group = new List<Student_GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    Student_GroupDTO group = new Student_GroupDTO();

                    group.ID = (int)reader["id"];
                    group.GroupID = (int)reader["GroupID"];
                    group.UserID = (int)reader["UserID"];
                    student_group.Add(group);
                }
            }
            reader.Close();
            return student_group;
        }
        public List<Student_GroupDTO> Student_Group_GetByGroupID(SqlConnection connection, Student_GroupDTO student_Group)
        {
            connection.Open();
            string sqlExpression = "Student_Group_GetByGroupID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter groupParam = new SqlParameter("@GroupID", student_Group.GroupID);
            command.Parameters.Add(groupParam);
            SqlDataReader reader = command.ExecuteReader();
            List<Student_GroupDTO> student_group = new List<Student_GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    Student_GroupDTO group = new Student_GroupDTO();

                    group.ID = (int)reader["id"];
                    group.GroupID = (int)reader["GroupID"];
                    group.UserID = (int)reader["UserID"];
                    student_group.Add(group);
                }
            }
            reader.Close();
            return student_group;
        }
        public int Student_Group_DeleteByID(SqlConnection connection, Student_GroupDTO student_Group)
        {
            connection.Open();
            string sqlExpression = "Student_Group_DeleteByID";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter idParam = new SqlParameter("@ID", student_Group.ID);
            command.Parameters.Add(idParam);

            return command.ExecuteNonQuery();
        }
        public int Student_Group_DeleteByGroupID(SqlConnection connection, Student_GroupDTO student_Group)
        {
            connection.Open();
            string sqlExpression = "Student_Group_DeleteByGroupID";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter groupParam = new SqlParameter("@GroupID", student_Group.GroupID);
            command.Parameters.Add(groupParam);

            return command.ExecuteNonQuery();
        }
        public int Student_Group_DeleteByUserID(SqlConnection connection, Student_GroupDTO student_Group)
        {
            connection.Open();
            string sqlExpression = "Student_Group_DeleteByUserID";

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter userParam = new SqlParameter("@UserID", student_Group.UserID);
            command.Parameters.Add(userParam);

            return command.ExecuteNonQuery();
        }
    }
}
