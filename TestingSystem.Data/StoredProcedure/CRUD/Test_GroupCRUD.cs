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
     public class TestGroupCRUD
    {
        public int Add(TestGroupDTO testgroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_Add @GroupId, @TestId, @startDate, @endDate";
                return connection.Query<int>(sqlExpression, testgroup).FirstOrDefault();
            }
        }

        public List<TestGroupDTO> GetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_GetAll";
                return connection.Query<TestGroupDTO>(sqlExpression).ToList();
            }
        }


        public List<TestGroupDTO> GetByGroupId(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_GetByGroupId";
                return connection.Query<TestGroupDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TestGroupDTO> GetByGroupIdTestId(TestGroupDTO testgroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_GetByGroupId_TestId";
                return connection.Query<TestGroupDTO>(sqlExpression, testgroup, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TestGroupDTO> GetByTestId(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_GetByTestId";
                return connection.Query<TestGroupDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void Update(TestGroupDTO testgroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_Update";
                connection.Execute(sqlExpression, testgroup, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteByGroupId(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_DeleteByGroupId";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteByGroupIdTestId(TestGroupDTO testgroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_DeleteByGroupId_TestId";
                connection.Execute(sqlExpression, testgroup, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteByTestId(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_DeleteByTestId";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
