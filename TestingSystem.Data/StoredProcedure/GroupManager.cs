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
        public List<GroupDTO> GetGroupByTeacherId( int id)//все группы преподавателя
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_GetByTeacherID @TeacherID";
                return connection.Query<GroupDTO>(sqlExpression, new { id }).ToList();
            }
        }
        
        public List<TeacherGroupsWithStudentsDTO> GetGroupsWithStudentsByTeacherID(int teacherId)
        {
            List<TeacherGroupsWithStudentsDTO> result = null;
            using(IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetTeacherGroupsWithStudentsById";
                connection.Query<TeacherGroupsWithStudentsDTO, UserDTO, TeacherGroupsWithStudentsDTO>(sqlExpression, (group, user)=>
                {
                    if (result == null)
                    {
                        result = new List<TeacherGroupsWithStudentsDTO>();
                        group.Students = new List<UserDTO>();
                        group.Students.Add(user);
                        result.Add(group);
                    }
                    if (!result.Any(r => r.GroupID == group.GroupID))
                    {
                        group.Students = new List<UserDTO>();
                        group.Students.Add(user);
                        result.Add(group);
                    }
                    else
                    {
                        int id = result.FindIndex(r=>r.GroupID==group.GroupID);
                        if (!result[id].Students.Any(r => r.ID == user.ID))
                        {
                            result[id].Students.Add(user);
                        }
                    }
                    return group;
                }, new { teacherId },splitOn:"id", commandType: CommandType.StoredProcedure).ToList();
            }
            return result;
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

        public int DeleteStudentFromGroup(int userId, int groupId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "DeleteStudentFromGroup";
            return connection.Execute(sqlExpression, new { userId, groupId}, commandType: CommandType.StoredProcedure);
        }

        public int DeleteTeacherFromGroup(int userId, int groupId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "DeleteTeacherFromGroup";
            return connection.Execute(sqlExpression, new { userId, groupId }, commandType: CommandType.StoredProcedure);
        }
    }
}
