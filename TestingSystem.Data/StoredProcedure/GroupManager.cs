using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Data;
using TestingSystem.Data.DTO;
using Dapper;

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

                    group.id = (int)reader["id"];
                    group.name = (string)reader["Name"];
                    group.startDate = (DateTime)reader["StartDate"];
                    group.endDate = (DateTime)reader["EndDate"];
                    groups.Add(group);
                }
            }
            reader.Close();
            return groups;
        }

        public List<UserDTO> GetAllStudents(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_GetAllStudents";
                return connection.Query<UserDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
