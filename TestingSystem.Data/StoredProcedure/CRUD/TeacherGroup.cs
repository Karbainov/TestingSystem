using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    public class TeacherGroup
    {
        public bool Add(TeacherGroupDTO teacherGroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_Add @UserID, @GroupID";
                return connection.Query<bool>(sqlExpression, teacherGroup).FirstOrDefault();
            }
        }
        public List<TeacherGroupDTO> GetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_GetAll";
                return connection.Query<TeacherGroupDTO>(sqlExpression).ToList();
            }
        }
        public TeacherGroupDTO GetById(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_GetByID";
                return connection.Query<TeacherGroupDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<TeacherGroupDTO> GetAllByUserId(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_GetByUserID";
                return connection.Query<TeacherGroupDTO>(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<TeacherGroupDTO> GetAllByGroupId(int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_GetByGroupID";
                return connection.Query<TeacherGroupDTO>(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public int Delete(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_DeleteByID";
                return connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
        public int DeleteByUserIdGroupId(int userId, int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_DeleteByUserIdGroupId";
                return connection.Execute(sqlExpression, new { userId, groupId }, commandType: CommandType.StoredProcedure);
            }
        }
        public int DeleteByUserId(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_DeleteByUserID";
                return connection.Execute(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure);
            }
        }
        public int DeleteByGroupId(int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_DeleteByGroupID";
                return connection.Execute(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
