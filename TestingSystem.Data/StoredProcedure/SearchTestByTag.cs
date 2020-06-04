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
//    public class SearchTestByTag
//    {
//        public List<SearchTestByTagDTO> SearchTestByTagOr(string tag1, string tag2, string tag3)
//        {

//            using (IDbConnection connection = Connection.GetConnection())
//            {
//                string sqlExpression = "SearchTestByTagOr";
//                return connection.Query<SearchTestByTagDTO>(sqlExpression, new { tag1, tag2, tag3 }, commandType: CommandType.StoredProcedure).ToList();
//            }
//        }

//        public List<SearchTestByTagDTO> SearchTestByTagAnd(string tag1, string tag2, string tag3)
//        {

//            using (IDbConnection connection = Connection.GetConnection())
//            {
//                string sqlExpression = "SearchTestByTagAnd";
//                return connection.Query<SearchTestByTagDTO>(sqlExpression, new { tag1, tag2, tag3 }, commandType: CommandType.StoredProcedure).ToList();
//            }
//        }
//    }
//}
