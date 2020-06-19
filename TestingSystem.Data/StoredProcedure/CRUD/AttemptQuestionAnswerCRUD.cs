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
    public class AttemptQuestionAnswerCRUD
    {
        public int Add(AttemptQuestionAnswerDTO aQA)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_Add @AttemptID, @QuestionID, @AnswerID";
            return connection.Query<int>(sqlExpression, aQA).FirstOrDefault();
        }

        public List<AttemptQuestionAnswerDTO> GetAll()
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetAll";
            return connection.Query<AttemptQuestionAnswerDTO>(sqlExpression).ToList();

        }

        public AttemptQuestionAnswerDTO GetById(int id)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetById";
            return connection.Query<AttemptQuestionAnswerDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();

        }

        public List<AttemptQuestionAnswerDTO> GetByAttemptId(int attemptId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetByAttemptId";
            return connection.Query<AttemptQuestionAnswerDTO>(sqlExpression, new { attemptId }, commandType: CommandType.StoredProcedure).ToList();
        }

        public List<AttemptQuestionAnswerDTO> GetByQuestionId(int questionId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetByQuestionId";
            return connection.Query<AttemptQuestionAnswerDTO>(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure).ToList();

        }
        
        public List<AttemptQuestionAnswerDTO> GetByAnswerId(int answerId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetByAnswerId";
            return connection.Query<AttemptQuestionAnswerDTO>(sqlExpression, new { answerId }, commandType: CommandType.StoredProcedure).ToList();
        }

        public void Delete(int id)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Question_Answer_Delete";
            connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
        }
        
        public void DeleteByAttemptId(int attemptId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Question_Answer_DeleteByAttemptId";
            connection.Execute(sqlExpression, new { attemptId }, commandType: CommandType.StoredProcedure);
        }
        
        public void DeleteByQuestionId(int questionId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Question_Answer_DeleteByQuestionId";
            connection.Execute(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure);
        }
        
        public void DeleteByAnswerId(int answerId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Question_Answer_DeleteByAnswerId";
            connection.Execute(sqlExpression, new { answerId }, commandType: CommandType.StoredProcedure);
        }
    }
}