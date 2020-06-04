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
        public List<TestDTO> Test_Attempt_GetLate(UserDTO user)//просроченные тесты студента
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Attempt_GetLate @UserID";
                return connection.Query<TestDTO>(sqlExpression, user).ToList();
            }
            //connection.Open();
            //string sqlExpression = "Test_Attempt_GetLate";
            //SqlCommand command = new SqlCommand(sqlExpression, connection);
            //command.CommandType = System.Data.CommandType.StoredProcedure;


            //SqlParameter idParam = new SqlParameter("@UserID", user.ID);
            //command.Parameters.Add(idParam);


            //SqlDataReader reader = command.ExecuteReader();

            //List<TestDTO> test = new List<TestDTO>();
            //if (reader.HasRows) // если есть данные
            //{

            //    while (reader.Read()) // построчно считываем данные
            //    {
            //        TestDTO test1 = new TestDTO();

            //        test1.Id = (int)reader["id"];
            //        test1.name = (string)reader["Name"];
            //        test1.duration = (TimeSpan)reader["DurationTime"];
            //        test1.score= (int)reader["SuccessScore"];
            //        test.Add(test1);
            //    }
            //}
            //reader.Close();
            //return test;
        }
        public List<Question_AnswerDTO> Answer_GetCorrectByTestID(TestDTO test)//нахождение правильных ответов теста
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Answer_GetCorrectByTestID @TestID";
                return connection.Query<Question_AnswerDTO>(sqlExpression, test).ToList();
            }
            //connection.Open();
            //string sqlExpression = "Answer_GetCorrectByTestID";
            //SqlCommand command = new SqlCommand(sqlExpression, connection);
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            //SqlParameter questionParam = new SqlParameter("@TestID", test.Id);
            //command.Parameters.Add(questionParam);
            //SqlDataReader reader = command.ExecuteReader();

            //List<Question_AnswerDTO> answers = new List<Question_AnswerDTO>();
            //if (reader.HasRows) // если есть данные
            //{

            //    while (reader.Read()) // построчно считываем данные
            //    {
            //        Question_AnswerDTO answer = new Question_AnswerDTO();
            //        answer.Answer_Value = (string)reader["Answer.Value"];
            //        answer.Question_Value = (string)reader["Question.Value"];
            //        answers.Add(answer);
            //    }
            //}
            //reader.Close();
            //return answers;
        }
        public List<Question_AnswerDTO> Attempt_GetQuestionAndAnswer(AttemptDTO attempt)//все вопросы и ответы попытки
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Attempt_GetQuestionAndAnswer @AttemptID";
                return connection.Query<Question_AnswerDTO>(sqlExpression, attempt).ToList();
            }
            //connection.Open();
            //string sqlExpression = "Attempt_GetQuestionAndAnswer";
            //SqlCommand command = new SqlCommand(sqlExpression, connection);
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            //SqlParameter attemptParam = new SqlParameter("@AttemptID", attempt.id);
            //command.Parameters.Add(attemptParam);
            //SqlDataReader reader = command.ExecuteReader();

            //List<Question_AnswerDTO> question_Answers = new List<Question_AnswerDTO>();
            //if (reader.HasRows) // если есть данные
            //{

            //    while (reader.Read()) // построчно считываем данные
            //    {
            //        Question_AnswerDTO question_Answer = new Question_AnswerDTO();

            //        question_Answer.Answer_Value = (string)reader["[Answer].Value"];
            //        question_Answer.Question_Value = (string)reader["[Question].Value"];
            //        question_Answers.Add(question_Answer);
            //    }
            //}
            //reader.Close();
            //return question_Answers;
        }

        public int Attempt_DeleteConcrete(AttemptDTO attempt)//удаление попытки 
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Attempt_DeleteConcrete @UserID,@TestID,@Number";
                return connection.Execute(sqlExpression, attempt);
            }
            //connection.Open();
            //string sqlExpression = "Attempt_DeleteConcrete";
            //SqlCommand command = new SqlCommand(sqlExpression, connection);
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            //SqlParameter userParam = new SqlParameter("@UserID", attempt.userID);
            //command.Parameters.Add(userParam);
            //SqlParameter testParam = new SqlParameter("@TestID", attempt.testID);
            //command.Parameters.Add(testParam);
            //SqlParameter numberParam = new SqlParameter("@Number", attempt.number);
            //command.Parameters.Add(numberParam);
            //return command.ExecuteNonQuery();
        }

        public List<TagDTO> GetTestTags(TestDTO tests)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetTestTags @TestID";
                return connection.Query<TagDTO>(sqlExpression, tests, commandType: CommandType.StoredProcedure).ToList();

            }
        }

        public List<TestDTO> GetTestByTagpAndGroup(TagGroupNamesDTO names)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_GetByTagAndGroup @Tag_Name @Group_Name";
                return connection.Query<TestDTO>(sqlExpression, names, commandType: CommandType.StoredProcedure).ToList();
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

        public List<SearchTestByTagDTO> GetTestVSTagSearchOr(string tag1, string tag2, string tag3)
        {

            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "SearchTestByTagOr";
                return connection.Query<SearchTestByTagDTO>(sqlExpression, new { tag1, tag2, tag3 }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<SearchTestByTagDTO> GetTestVSTagSearchAnd(string tag1, string tag2, string tag3)
        {

            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "SearchTestByTagAnd";
                return connection.Query<SearchTestByTagDTO>(sqlExpression, new { tag1, tag2, tag3 }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

       /* public List<TestWithStatsDTO> GetCompletedTestsByUserID(int UserID)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetCompletedTestsByUserID";
                return connection.Query<TestWithStatsDTO>(sqlExpression, new { UserID }, commandType: CommandType.StoredProcedure).ToList();

            }
        }*/
    }
}
