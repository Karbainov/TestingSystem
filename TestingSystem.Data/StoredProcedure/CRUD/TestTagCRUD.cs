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
        public int Add(TestTagDTO testtag)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_Add @testId, @tagId";
                int testtagID = connection.Query<int>(sqlExpression, testtag).FirstOrDefault();
                testtag.ID = testtagID;
                return testtagID;
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

        public void Update(TestTagDTO testtag)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_Update";
                connection.Execute(sqlExpression, testtag, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteById(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Tag_DeleteById";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
