using System;
using System.Data.SqlClient;
using TestingSystem.Data.DTO;
using System.Collections.Generic;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    public class Question
    {
        public int Question_Add(SqlConnection connection, QuestionDTO question)
        {
            connection.Open();
            string sqlExpression = "Question_Add";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;



            SqlParameter TestIDParam = new SqlParameter("@TestID", question.TestID);
            command.Parameters.Add(TestIDParam);

            SqlParameter ValueParam = new SqlParameter("@Value", question.Value);
            command.Parameters.Add(ValueParam);

            SqlParameter TypeIDParam = new SqlParameter("@TypeID", question.TypeID);
            command.Parameters.Add(TypeIDParam);

            SqlParameter AnswersCountParam = new SqlParameter("@AnswersCount", question.AnswersCount);
            command.Parameters.Add(AnswersCountParam);

            SqlParameter WeightParam = new SqlParameter("@Weight", question.Weight);
            command.Parameters.Add(WeightParam);


            return command.ExecuteNonQuery();
        }

        public List<QuestionDTO> Question_GetAll(SqlConnection connection)
        {
            List<QuestionDTO> allRows = new List<QuestionDTO>();
            connection.Open();
            string sqlExpression = "Question_GetAll";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                QuestionDTO question = new QuestionDTO();

                question.ID = (int)reader["ID"];
                question.TestID = (int)reader["TestID"];
                question.Value = (string)reader["Value"];
                question.TypeID = (int)reader["TypeID"];
                question.AnswersCount = (byte)reader["AnswersCount"];
                question.Weight = (byte)reader["Weight"];

                allRows.Add(question);
            }
            reader.Close();
            connection.Close();
            return allRows;
        }

        public QuestionDTO Question_GetById(SqlConnection connection, int id)
        {
            QuestionDTO question = new QuestionDTO();
            connection.Open();
            string sqlExpression = "Question_GetById";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IdParam = new SqlParameter("@Id", id);
            command.Parameters.Add(IdParam);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                
                question.ID = (int)reader["ID"];
                question.TestID = (int)reader["TestID"];
                question.Value = (string)reader["Value"];
                question.TypeID = (int)reader["TypeID"];
                question.AnswersCount = (byte)reader["AnswersCount"];
                question.Weight = (byte)reader["Weight"];
 
            }

            reader.Close();
            connection.Close();
            return question;

        }

        public List<QuestionDTO> Question_GetByTestID(SqlConnection connection, int id)
        {
            List<QuestionDTO> allRows = new List<QuestionDTO>();
            connection.Open();
            string sqlExpression = "Question_GetByTestID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter TestIDParam = new SqlParameter("@TestID", id);
            command.Parameters.Add(TestIDParam);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                QuestionDTO question = new QuestionDTO();
                question.ID = (int)reader["ID"];
                question.TestID = (int)reader["TestID"];
                question.Value = (string)reader["Value"];
                question.TypeID = (int)reader["TypeID"];
                question.AnswersCount = (byte)reader["AnswersCount"];
                question.Weight = (byte)reader["Weight"];

                allRows.Add(question); 

            }

            reader.Close();
            connection.Close();
            return allRows;
        }

        public List<QuestionDTO> Question_GetByTypeID(SqlConnection connection, int id)
        {
            List<QuestionDTO> allRows = new List<QuestionDTO>();
            connection.Open();
            string sqlExpression = "Question_GetByTypeID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter TypeIDParam = new SqlParameter("@TypeID", id);
            command.Parameters.Add(TypeIDParam);

            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                QuestionDTO question = new QuestionDTO();
                question.ID = (int)reader["ID"];
                question.TestID = (int)reader["TestID"];
                question.Value = (string)reader["Value"];
                question.TypeID = (int)reader["TypeID"];
                question.AnswersCount = (byte)reader["AnswersCount"];
                question.Weight = (byte)reader["Weight"];

                allRows.Add(question);


            }

            reader.Close();
            connection.Close();

            return allRows;

        }

        public int Question_Update(SqlConnection connection, QuestionDTO question)
        {
            connection.Open();
            string sqlExpression = "Question_Update";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", question.ID);
            command.Parameters.Add(IDParam);

            SqlParameter TestIDParam = new SqlParameter("@TestID", question.TestID);
            command.Parameters.Add(TestIDParam);

            SqlParameter ValueParam = new SqlParameter("@Value", question.Value);
            command.Parameters.Add(ValueParam);

            SqlParameter TypeIDParam = new SqlParameter("@TypeID", question.TypeID);
            command.Parameters.Add(TypeIDParam);

            SqlParameter AnswersCountParam = new SqlParameter("@AnswersCount", question.AnswersCount);
            command.Parameters.Add(AnswersCountParam);

            SqlParameter WeightParam = new SqlParameter("@Weight", question.Weight);
            command.Parameters.Add(WeightParam);


            return command.ExecuteNonQuery();
        }

        public int Question_Delete(SqlConnection connection, int id)
        {
            connection.Open();
            string sqlExpression = "Question_Delete";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);


            return command.ExecuteNonQuery();
        }
    }
}

