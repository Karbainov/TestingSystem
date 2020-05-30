using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    class GroupManager
    {
        public List<GroupDTO> Group_GetByTeacherID(SqlConnection connection, UserDTO user)//все группы преподавателя
        {
            connection.Open();
            string sqlExpression = "Group_GetByTeacherID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter idParam = new SqlParameter("@TeacherID", user.ID);
            command.Parameters.Add(idParam);
            SqlDataReader reader = command.ExecuteReader();
            List<GroupDTO> groups = new List<GroupDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    GroupDTO group = new GroupDTO();

                    group.ID = (int)reader["id"];
                    group.Name = (string)reader["Name"];
                    group.StartDate = (DateTime)reader["StartDate"];
                    group.EndDate = (DateTime)reader["EndDate"];
                    groups.Add(group);
                }
            }
            reader.Close();
            return groups;
        }
    }
}
