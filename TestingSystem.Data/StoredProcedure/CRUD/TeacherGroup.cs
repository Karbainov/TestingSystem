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
    class TeacherGroup
    {
        public int Add(TeacherGroupDTO teacherGroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_Add @UserID, @GroupID";
                int teacherGroupID = connection.Query<int>(sqlExpression, teacherGroup).FirstOrDefault();
                teacherGroup.ID = teacherGroupID;
                return teacherGroupID;
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
        public TeacherGroupDTO GetByID(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_GetByID";
                return connection.Query<TeacherGroupDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public TeacherGroupDTO GetByUserID(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_GetByUserID";
                return connection.Query<TeacherGroupDTO>(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public TeacherGroupDTO GetByGroupID(int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_GetByGroupID";
                return connection.Query<TeacherGroupDTO>(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public void DeleteByID(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_DeleteByID";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteByUserIdGroupId(int userId, int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_DeleteByUserIdGroupId";
                connection.Execute(sqlExpression, new { userId, groupId }, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteByUserID(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_DeleteByUserID";
                connection.Execute(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteByGroupID(int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_DeleteByGroupID";
                connection.Execute(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
