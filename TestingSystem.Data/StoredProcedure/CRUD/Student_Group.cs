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
    public class Student_Group
    {
        public int StudentGroupAdd(Student_GroupDTO studentGroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_Add @UserID, @GroupID";
                int studentGroupID = connection.Query<int>(sqlExpression, studentGroup).FirstOrDefault();
                studentGroup.ID = studentGroupID;
                return studentGroupID;
            }
        }
        public List<Student_GroupDTO> StudentGroupGetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_GetAll";
                return connection.Query<Student_GroupDTO>(sqlExpression).ToList();
            }
        }
        public Student_GroupDTO StudentGroupGetByID(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_GetByID";
                return connection.Query<Student_GroupDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Student_GroupDTO StudentGroupGetByUserID(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_GetByUserID";
                return connection.Query<Student_GroupDTO>(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Student_GroupDTO StudentGroupGetByGroupID(int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_GetByGroupID";
                return connection.Query<Student_GroupDTO>(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public void StudentGroupDeleteByID(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_DeleteByID";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
        public void StudentGroupDeleteByUserID(int userId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_DeleteByUserID";
                connection.Execute(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure);
            }
        }
        public void StudentGroupDeleteByGroupID(int groupId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Student_Group_DeleteByGroupID";
                connection.Execute(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
