using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;


namespace TestingSystem.Data.StoredProcedure.CRUD
{
    public class TestTagCRUD
    {
        public int Add(TestTagDTO testTag)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_Add @testId, @tagId";
                return connection.Query<int>(sqlExpression, testTag).FirstOrDefault();
            }
        }

        public List<TestTagDTO> GetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_GetAll";
                return connection.Query<TestTagDTO>(sqlExpression).ToList();
            }
        }

        public TestTagDTO GetById(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_GetById";
                return connection.Query<TestTagDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<TestTagDTO> GetByTagId(int tagId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_GetByTagId";
                return connection.Query<TestTagDTO>(sqlExpression, new { tagId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TestTagDTO> GetByTestId(int testId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_GetByTestId";
                return connection.Query<TestTagDTO>(sqlExpression, new { testId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public TestTagDTO GetByTestIdTagId(int testId, int tagId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_GetByTestIdTagId";
                return connection.Query<TestTagDTO>(sqlExpression, new { testId, tagId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void Update(TestTagDTO testtag)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_Update";
                connection.Execute(sqlExpression, testtag, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_DeleteById";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteByTagId(int tagId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_DeleteByTagId";
                connection.Execute(sqlExpression, new { tagId }, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteByTestId(int testId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_DeleteByTestId";
                connection.Execute(sqlExpression, new { testId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteByTestIdTagId(int testId, int tagId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_DeleteByTestIdTagId";
                connection.Execute(sqlExpression, new { testId, tagId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
