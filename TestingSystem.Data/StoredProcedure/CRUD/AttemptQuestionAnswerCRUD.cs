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
            int aQAID = connection.Query<int>(sqlExpression, aQA).FirstOrDefault();
            aQA.ID = aQAID;
            return aQA.ID;
        }

        public List<AttemptQuestionAnswerDTO> GetAll()
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetAll";
            List<AttemptQuestionAnswerDTO> aQA = connection.Query<AttemptQuestionAnswerDTO>(sqlExpression).ToList();
            return aQA;

        }

        public AttemptQuestionAnswerDTO GetById(int id)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetById";
            AttemptQuestionAnswerDTO aQA = connection.Query<AttemptQuestionAnswerDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return aQA;

        }

        public List<AttemptQuestionAnswerDTO> GetByAttemptID(int attemptId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetByAttemptId";
            List<AttemptQuestionAnswerDTO> aQA = connection.Query<AttemptQuestionAnswerDTO>(sqlExpression, new { attemptId }, commandType: CommandType.StoredProcedure).ToList();
            return aQA;
        }

        public List<AttemptQuestionAnswerDTO> GetByQuestionID(int questionId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetByQuestionId";
            List<AttemptQuestionAnswerDTO> aQA = connection.Query<AttemptQuestionAnswerDTO>(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure).ToList();
            return aQA;

        }
        
        public List<AttemptQuestionAnswerDTO> GetByAnswerID(int answerId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetByAnswerId";
            List<AttemptQuestionAnswerDTO> aQA = connection.Query<AttemptQuestionAnswerDTO>(sqlExpression, new { answerId }, commandType: CommandType.StoredProcedure).ToList();
            return aQA;

        }

        public void Delete(int id)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Question_Answer_Delete";
            connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
        }
        
        public void DeleteByAttemptID(int attemptId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Question_Answer_DeleteByAttemptId";
            connection.Execute(sqlExpression, new { attemptId }, commandType: CommandType.StoredProcedure);
        }
        
        public void DeleteByQuestionID(int questionId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Question_Answer_DeleteByQuestionId";
            connection.Execute(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure);
        }
        
        public void DeleteByAnswerID(int answerId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Question_Answer_DeleteByAnswerId";
            connection.Execute(sqlExpression, new { answerId }, commandType: CommandType.StoredProcedure);
        }
    }
}