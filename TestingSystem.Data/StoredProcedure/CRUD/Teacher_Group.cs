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
    class Teacher_Group
    {
        public int TeacherGroupAdd(Teacher_GroupDTO teacherGroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_Add @UserID, @GroupID";
                int teacherGroupID = connection.Query<int>(sqlExpression, teacherGroup).FirstOrDefault();
                teacherGroup.ID = teacherGroupID;
                return teacherGroupID;
            }
        }
        public List<Teacher_GroupDTO> TeacherGroupGetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_GetAll";
                return connection.Query<Teacher_GroupDTO>(sqlExpression).ToList();
            }
        }
        public Teacher_GroupDTO TeacherGroupGetByID(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_GetByID";
                return connection.Query<Teacher_GroupDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Teacher_GroupDTO TeacherGroupGetByUserID(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_GetByUserID";
                return connection.Query<Teacher_GroupDTO>(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Teacher_GroupDTO TeacherGroupGetByGroupID(int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_GetByGroupID";
                return connection.Query<Teacher_GroupDTO>(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public void TeacherGroupDeleteByID(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_DeleteByID";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
        public void TeacherGroupDeleteByUserID(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_DeleteByUserID";
                connection.Execute(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure);
            }
        }
        public void TeacherGroupDeleteByGroupID(int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Teacher_Group_DeleteByGroupID";
                connection.Execute(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
