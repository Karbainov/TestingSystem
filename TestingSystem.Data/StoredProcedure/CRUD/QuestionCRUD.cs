using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    public class QuestionCRUD
    {
        public int Add(QuestionDTO question)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Question_Add @TestID, @Value, @TypeID, @AnswersCount, @Weight";
            int questionID = connection.Query<int>(sqlExpression, question).FirstOrDefault();
            question.ID = questionID;
            return question.ID;
        }

        public List<QuestionDTO> GetAll()
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Question_GetAll";
            List<QuestionDTO> questions = connection.Query<QuestionDTO>(sqlExpression).ToList();
            return questions;

        }

        public QuestionDTO GetById(int id)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Question_GetById";
            QuestionDTO question = connection.Query<QuestionDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return question;

        }

        public List<QuestionDTO> GetByTestID(int Testid)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Question_GetByTestId";
            List<QuestionDTO> questions = connection.Query<QuestionDTO>(sqlExpression, new { Testid }, commandType: CommandType.StoredProcedure).ToList();
            return questions;
        }

        public List<QuestionDTO> GetByTypeID(int Typeid)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Question_GetByTypeId";
            List<QuestionDTO> questions = connection.Query<QuestionDTO>(sqlExpression, new { Typeid }, commandType: CommandType.StoredProcedure).ToList();
            return questions;

        }

        public void Update(QuestionDTO question)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Question_Update";
            connection.Execute(sqlExpression, question, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Question_Delete";
            connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}

