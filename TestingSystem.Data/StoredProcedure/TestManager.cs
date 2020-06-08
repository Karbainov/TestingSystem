using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class TestManager
    {
        public List<TestDTO> GetLateAttempt(int userID)//просроченные тесты студента
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Attempt_GetLate @UserID";
                return connection.Query<TestDTO>(sqlExpression,new { userID }).ToList();
            }
            
        }
        public List<QuestionAnswerDTO> GetCorrectAnswerByTestID(int testID)//нахождение правильных ответов теста
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Answer_GetCorrectByTestID @TestID";
                return connection.Query<QuestionAnswerDTO>(sqlExpression,new { testID }).ToList();
            }
            
        }
        public List<QuestionAnswerDTO> GetQuestionAndAnswerFromAttempt(int attemptID)//все вопросы и ответы попытки
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Attempt_GetQuestionAndAnswer @AttemptID";
                return connection.Query<QuestionAnswerDTO>(sqlExpression,new{ attemptID}).ToList();
            }
           
        }

        public int DeleteConcreteAttempt(AttemptDTO attempt)//удаление попытки 
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Attempt_DeleteConcrete @UserID,@TestID,@Number";
                return connection.Execute(sqlExpression, attempt);
            }
           
        }

        public List<TagDTO> GetTestTags(TestDTO tests)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetTestTags @TestID";
                return connection.Query<TagDTO>(sqlExpression, tests, commandType: CommandType.StoredProcedure).ToList();

            }
        }

        public List<TestDTO> GetTestByTagpAndGroup(TagGroupDTO dto)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_ByTagAndGroup @Tag_Name @Group_ID";
                return connection.Query<TestDTO>(sqlExpression, dto, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TestDTO> GetTestByGroupId(int GroupID)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetTestsByGroupId";
                return connection.Query<TestDTO>(sqlExpression, new { GroupID }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<SearchTestByTagDTO> GetTestVSTagSearchOr(params string[] tag)
        {

            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "SearchTestByTagOr";
                return connection.Query<SearchTestByTagDTO>(sqlExpression, new { tag }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<SearchTestByTagDTO> GetTestVSTagSearchAnd(params string[] tag)
        {

            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "SearchTestByTagAnd";
                return connection.Query<SearchTestByTagDTO>(sqlExpression, new { tag }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TestAttemptDTO> GetCompletedTestsByUserID(int UserID)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetCompletedTestsByUserID";
                return connection.Query<TestAttemptDTO>(sqlExpression, new { UserID }, commandType: CommandType.StoredProcedure).ToList();

            }
        }

        public void DeleteTest(int ID)
        {
                var connection = Connection.GetConnection();
                string sqlExpression = "DeleteTest";
                connection.Execute(sqlExpression, ID, commandType: CommandType.StoredProcedure);
        }
        public List<AllStudentTestsDTO> GetBestResultOfTestByGroupID(int groupID)
        {
            using(IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_BestGroupResult @GroupID";
                return connection.Query<AllStudentTestsDTO>(sqlExpression, new { groupID }).ToList();
            }
        }
        //public List<TagDTO> GetTestTags (TestDTO tests )
        //{
        //    using (IDbConnection connection = Connection.GetConnection())
        //    {
        //        string sqlExpression = "GetTestTags @TestID";
        //        return connection.Query<TagDTO>(sqlExpression,  tests , commandType: CommandType.StoredProcedure).ToList();
              
        //    }
        //}

        //public List<TestDTO> GetTestByTagpAndGroup (TagGroupDTO dto)
        //{
        //    using (IDbConnection connection = Connection.GetConnection())
        //    {
        //        string sqlExpression = "Test_ByTagAndGroup @Tag_Name @Group_ID";
        //        return connection.Query<TestDTO>(sqlExpression, dto, commandType: CommandType.StoredProcedure).ToList();
        //    }
        //}
    }
}
