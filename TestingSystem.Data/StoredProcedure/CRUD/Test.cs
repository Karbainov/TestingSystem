using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    public class Test
    {
        public Test()
        {
        }

        public int TestCreate(TestDTO test)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Test_Add";
            int testID = connection.Query<int>(sqlExpression, test).FirstOrDefault();
            test.ID = testID;
            return test.ID;            
        }

        public List<TestDTO> TestRead()
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Test_GetAll";           
            List<TestDTO> tests = new List<TestDTO>();
            tests = connection.Query<TestDTO>(sqlExpression).ToList();
            return tests;
        }

        public List<TestDTO> TestReadById(int id)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Test_GetById";
            List<TestDTO> tests = new List<TestDTO>();
            tests = connection.Query<TestDTO>(sqlExpression, new {id}).ToList();
            return tests;
        }

        public void TestUpdate(TestDTO test)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Test_Update";
            connection.Execute(sqlExpression, test);
        }

        public void TestDelete(int id)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Test_Delete";
            connection.Execute(sqlExpression, new { id });
        }
    }
}
