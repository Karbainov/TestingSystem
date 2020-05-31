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

                    test1.Id = (int)reader["id"];
                    test1.name = (string)reader["Name"];
                    test1.duration = (TimeSpan)reader["DurationTime"];
                    test1.score= (int)reader["SuccessScore"];
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
            SqlParameter questionParam = new SqlParameter("@QuestionID", test.Id);
            command.Parameters.Add(questionParam);
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
        public List<Question_AnswerDTO> Attempt_GetQuestionAndAnswer(SqlConnection connection, AttemptDBO attempt)
        {
            connection.Open();
            string sqlExpression = "Attempt_GetQuestionAndAnswer";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter attemptParam = new SqlParameter("@AttemptID", attempt.id);
            command.Parameters.Add(attemptParam);
            SqlDataReader reader = command.ExecuteReader();

            List<Question_AnswerDTO> question_Answers = new List<Question_AnswerDTO>();
            if (reader.HasRows) // если есть данные
            {

                while (reader.Read()) // построчно считываем данные
                {
                    Question_AnswerDTO question_Answer = new Question_AnswerDTO();

                    question_Answer.Answer_Value = (string)reader["[Answer].Value"];
                    question_Answer.Question_Value = (string)reader["[Question].Value"];
                    question_Answers.Add(question_Answer);
                }
            }
            reader.Close();
            return question_Answers;
        }
    }
}
