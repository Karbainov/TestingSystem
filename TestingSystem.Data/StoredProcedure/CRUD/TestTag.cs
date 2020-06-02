using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;


namespace TestingSystem.Data.StoredProcedure.CRUD
{
    public class TestTag
    {
        public int Create(TestTagDTO testtag)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "TestTag_Add";
                int testtagID = connection.Query<int>(sqlExpression, testtag, commandType: CommandType.StoredProcedure).FirstOrDefault();
                testtag.ID = testtagID;
                return testtagID;
            }
        }

        public List<TestTagDTO> ReadAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "TestTag_GetAll";
                List<TestTagDTO> testtags = new List<TestTagDTO>();
                return connection.Query<TestTagDTO>(sqlExpression, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public TestTagDTO Read(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "TestTag_GetById";
                return connection.Query<TestTagDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void Update(TestTagDTO testtag)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "TestTag_Update";
                connection.Execute(sqlExpression, testtag, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "TestTag_Delete";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
