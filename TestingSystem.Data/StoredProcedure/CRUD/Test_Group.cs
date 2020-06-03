using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
     public class TestGroup
    {
        public int TestGroupAdd(TestGroupDTO testgroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_Add @GroupId, @TestId, @startDate, @endDate";
                int testgroupID = connection.Query<int>(sqlExpression, testgroup).FirstOrDefault();
                testgroup.id = testgroupID;
                return testgroupID;
            }
        }

        public List<TestGroupDTO> TestGroupGetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_GetAll";
                return connection.Query<TestGroupDTO>(sqlExpression).ToList();
            }
        }


        public List<TestGroupDTO> TestGroupGetByGroupId(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_GetByGroupId";
                return connection.Query<TestGroupDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TestGroupDTO> TestGroupGetByGroupIdTestId(TestGroupDTO testgroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_GetByGroupId_TestId";
                return connection.Query<TestGroupDTO>(sqlExpression, testgroup, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TestGroupDTO> TestGroupGetByTestId(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_GetByTestId";
                return connection.Query<TestGroupDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void TestGroupUpdate(TestGroupDTO testgroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_Update";
                connection.Execute(sqlExpression, testgroup, commandType: CommandType.StoredProcedure);
            }
        }

        public void TestGroupDeleteByGroupId(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_DeleteByGroupId";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void TestGroupDeleteByGroupIdTestId(TestGroupDTO testgroup)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_DeleteByGroupId_TestId";
                connection.Execute(sqlExpression, testgroup, commandType: CommandType.StoredProcedure);
            }
        }

        public void TestGroupDeleteByTestId(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Group_DeleteByTestId";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
