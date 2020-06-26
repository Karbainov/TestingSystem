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

        public List<TeacherGroupsWithStudentsDTO> GetGroupsWithStudentsByTeacherID(int teacherID)
        {
            using(IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetTeacherGroupsWithStudentsById @TeacherID";
                return connection.Query<TeacherGroupsWithStudentsDTO>(sqlExpression, new { teacherID }).ToList();
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
        public List<UserDTO> GetTeacherByGroupId(int groupId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "GetTeacherByGroupID";
            List<UserDTO> teachers = connection.Query<UserDTO>(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure).ToList();
            return teachers;
        }

        public void DeleteStudentFromGroup(int userId, int groupId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "DeleteStudentFromGroup";
            connection.Execute(sqlExpression, new { userId, groupId}, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTeacherFromGroup(int userId, int groupId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "DeleteTeacherFromGroup";
            connection.Execute(sqlExpression, new { userId, groupId }, commandType: CommandType.StoredProcedure);
        }
    }
}
