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
  public class GroupManager
    {
        public List<GroupDTO> GetGroupByTeacherID( int id)//все группы преподавателя
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_GetByTeacherID @TeacherID";
                return connection.Query<GroupDTO>(sqlExpression, new { id }).ToList();
            }
           
        }

        public List<UserDTO> GetAllStudents(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_GetAllStudents";
                return connection.Query<UserDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<UserDTO> GetTeacherByGroupId(int Groupid)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "GetTeacherByGroupID";
            List<UserDTO> teachers = connection.Query<UserDTO>(sqlExpression, new { Groupid }, commandType: CommandType.StoredProcedure).ToList();
            return teachers;
        }
    }
}
