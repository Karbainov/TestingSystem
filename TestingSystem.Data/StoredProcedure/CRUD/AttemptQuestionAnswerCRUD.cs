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
        public int AttemptQuestionAnswerAdd(AttemptQuestionAnswerDTO aQA)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_Add @AttemptID, @QuestionID, @AnswerID";
            int aQAID = connection.Query<int>(sqlExpression, aQA).FirstOrDefault();
            aQA.ID = aQAID;
            return aQA.ID;
        }

        public List<AttemptQuestionAnswerDTO> AttemptQuestionAnswerGetAll()
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetAll";
            List<AttemptQuestionAnswerDTO> aQA = connection.Query<AttemptQuestionAnswerDTO>(sqlExpression).ToList();
            return aQA;

        }

        public AttemptQuestionAnswerDTO AttemptQuestionAnswerGetById(int id)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetById";
            AttemptQuestionAnswerDTO aQA = connection.Query<AttemptQuestionAnswerDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return aQA;

        }

        public List<AttemptQuestionAnswerDTO> AttemptQuestionAnswerGetByAttemptID(int attemptId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetByAttemptId";
            List<AttemptQuestionAnswerDTO> aQA = connection.Query<AttemptQuestionAnswerDTO>(sqlExpression, new { attemptId }, commandType: CommandType.StoredProcedure).ToList();
            return aQA;
        }

        public List<AttemptQuestionAnswerDTO> AttemptQuestionAnswerGetByQuestionID(int questionId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetByQuestionId";
            List<AttemptQuestionAnswerDTO> aQA = connection.Query<AttemptQuestionAnswerDTO>(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure).ToList();
            return aQA;

        }
        
        public List<AttemptQuestionAnswerDTO> AttemptQuestionAnswerGetByAnswerID(int answerId)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Attempt_Question_Answer_GetByAnswerId";
            List<AttemptQuestionAnswerDTO> aQA = connection.Query<AttemptQuestionAnswerDTO>(sqlExpression, new { answerId }, commandType: CommandType.StoredProcedure).ToList();
            return aQA;

        }

        public void AttemptQuestionAnswerDelete(int id)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Question_Answer_Delete";
            connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
        }
        
        public void AttemptQuestionAnswerDeleteByAttemptID(int attemptId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Question_Answer_DeleteByAttemptId";
            connection.Execute(sqlExpression, new { attemptId }, commandType: CommandType.StoredProcedure);
        }
        
        public void AttemptQuestionAnswerDeleteByQuestionID(int questionId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Question_Answer_DeleteByQuestionId";
            connection.Execute(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure);
        }
        
        public void AttemptQuestionAnswerDeleteByAnswerID(int answerId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Attempt_Question_Answer_DeleteByAnswerId";
            connection.Execute(sqlExpression, new { answerId }, commandType: CommandType.StoredProcedure);
        }
    }
}