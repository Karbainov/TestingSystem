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
                int studentGroupID = connection.Query<int>(sqlExpression, studentGroup).FirstOrDefault();
                studentGroup.ID = studentGroupID;
                return studentGroupID;
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
        public StudentGroupDTO GetByID(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_GetByID";
                return connection.Query<StudentGroupDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public StudentGroupDTO GetByUserID(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_GetByUserID";
                return connection.Query<StudentGroupDTO>(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public StudentGroupDTO GetByGroupID(int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_GetByGroupID";
                return connection.Query<StudentGroupDTO>(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public void DeleteByID(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_DeleteByID";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteByUserID(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_DeleteByUserID";
                connection.Execute(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteByGroupID(int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_DeleteByGroupID";
                connection.Execute(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
