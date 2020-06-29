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
    public class StudentGroup
    {
        public int Add(StudentGroupDTO studentGroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_Add @UserID, @GroupID";
                return connection.Query<int>(sqlExpression, studentGroup).FirstOrDefault();
            }
        }
        public List<StudentGroupDTO> GetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_GetAll";
                return connection.Query<StudentGroupDTO>(sqlExpression).ToList();
            }
        }
        public StudentGroupDTO GetById(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_GetByID";
                return connection.Query<StudentGroupDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public StudentGroupDTO GetByUserId(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_GetByUserID";
                return connection.Query<StudentGroupDTO>(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public StudentGroupDTO GetByGroupId(int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_GetByGroupID";
                return connection.Query<StudentGroupDTO>(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public int Delete(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_DeleteByID";
                return connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
        public int DeleteByUserIdGroupId(int userId, int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_DeleteByUserIdGroupId";
                return connection.Execute(sqlExpression, new { userId, groupId }, commandType: CommandType.StoredProcedure);
            }
        }
        public int DeleteByUserId(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_DeleteByUserID";
                return connection.Execute(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure);
            }
        }
        public int DeleteByGroupId(int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_DeleteByGroupID";
                return connection.Execute(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
