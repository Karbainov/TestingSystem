using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    class TestManager
    {
        public List<TestDTO> Test_Attempt_GetLate(SqlConnection connection, UserDTO user)//просроченные тесты студента
        {

            connection.Open();
            string sqlExpression = "Test_Attempt_GetLate";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter idParam = new SqlParameter("@UserID", user.ID);
            command.Parameters.Add(idParam);
            SqlDataReader reader = command.ExecuteReader();

            List<TestDTO> test = new List<TestDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    TestDTO test1 = new TestDTO();

                    test1.ID = (int)reader["id"];
                    test1.Name = (string)reader["Name"];
                    test1.DurationTime = (DateTime)reader["DurationTime"];
                    test1.SuccessScore = (int)reader["SuccessScore"];
                    test.Add(test1);
                }
            }
            reader.Close();
            return test;
        }
        public List<AnswerDTO> Answer_GetCorrectByQuestionID(SqlConnection connection,TestDTO test)//нахождение правильных ответов вопроса
        {
            connection.Open();
            string sqlExpression = "Answer_GetCorrectByQuestionID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter questionParam = new SqlParameter("@QuestionID", test.ID);
            command.Parameters.Add(idParam);
            SqlDataReader reader = command.ExecuteReader();

            List<AnswerDTO> answers = new List<AnswerDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    AnswerDTO answer= new AnswerDTO();

                    answer.ID = (int)reader["id"];
                    answer.QuestionID = (int)reader["QuestionID"];
                    answer.Value = (string)reader["Value"];
                    answer.Correct = (bool)reader["Correct"];
                    answers.Add(answer);
                }
            }
            reader.Close();
            return answers;
        }
    }
}
