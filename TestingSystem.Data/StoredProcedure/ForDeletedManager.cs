using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class ForDeletedManager
    {
        public List<UserDTO> GetDeletedUsers()
        {
            using(var connection = Connection.GetConnection())
            {
                string sqlExpression = "User_GetDeleted";
                return connection.Query<UserDTO>(sqlExpression).ToList();
            }
        }

        public int RestoreUser(int id)
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Restore @id";
                return connection.Query<int>(sqlExpression, new { id }).FirstOrDefault();
            }
        }
        public List<TestDTO> GetDeletedTests()
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_GetDeleted";
                return connection.Query<TestDTO>(sqlExpression).ToList();
            }
        }
        public int RestoreTest(int id)
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Restore @id";
                return connection.Query<int>(sqlExpression, new { id }).FirstOrDefault();
            }
        }
        public List<QuestionDTO> GetDeletedQuestions()
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "Question_GetDeleted";
                return connection.Query<QuestionDTO>(sqlExpression).ToList();
            }
        }
        public int RestoreQuestion(int id)
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "Question_Restore @id";
                return connection.Query<int>(sqlExpression, new { id }).FirstOrDefault();
            }
        }
        public List<GroupDTO> GetDeletedGroups()
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_GetDeleted";
                return connection.Query<GroupDTO>(sqlExpression).ToList();
            }
        }
        public int RestoreGroup(int id)
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_Restore @id";
                return connection.Query<int>(sqlExpression, new { id }).FirstOrDefault();
            }
        }
        public List<TestQuestionTagDTO> GetDeletedWithTests()
        {
            using(var connection = Connection.GetConnection())
            {
                List<TestQuestionTagDTO> dTOs;
                var TestDictionary = new Dictionary<int, TestQuestionTagDTO>();
                string sqlExpression = "GetdeletedTests";
                    connection.Query< TestQuestionTagDTO, QuestionDTO, TagWithTestIDDTO, TestQuestionTagDTO>(sqlExpression, ( test , question , tag )=>
                {
                    TestQuestionTagDTO testEntry;
                    if(!TestDictionary.TryGetValue(test.ID,out testEntry))
                    {
                        testEntry = test;
                        testEntry.Questions = new List<QuestionDTO>();
                        testEntry.Questions.Add( question);
                        testEntry.Tags = new List<TagWithTestIDDTO>();
                        TestDictionary.Add(testEntry.ID, testEntry);
                    }
                    testEntry.Tags.Add(tag);
                    return testEntry;
                }
                ,splitOn:"TestID,IDtest" ).ToList();
                dTOs = new List<TestQuestionTagDTO>(TestDictionary.Values);
                return dTOs;
            }
        }
    }
}
