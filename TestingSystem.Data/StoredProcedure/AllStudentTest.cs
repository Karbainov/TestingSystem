//using Dapper;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using TestingSystem.Data.DTO;

//namespace TestingSystem.Data.StoredProcedure
//{
//    public class AllStudentTest
//    {
//        public List<AllStudentTestsDTO> AllStudentTests(int id)
//        {
//            using (IDbConnection connection = Connection.GetConnection())
//            {
//                string sqlExpression = "AllStudentTests ";
//                return connection.Query<AllStudentTestsDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
//            }
//        }
//    }
//}
