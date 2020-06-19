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
    public class AnswerCRUD
    {
        public int Add(AnswerDTO answer)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Answer_Add @questionID, @value, @correct";
            return connection.Query<int>(sqlExpression, answer).FirstOrDefault();
        }

        public List<AnswerDTO> GetAll()
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Answer_GetAll";
            return connection.Query<AnswerDTO>(sqlExpression).ToList();
        }

        public AnswerDTO GetById(int id)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Answer_GetById";
            return connection.Query<AnswerDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        
        public List<AnswerDTO> GetByQuestionId(int questionId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Answer_GetByQuestionID";
            return connection.Query<AnswerDTO>(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure).ToList();
        }
        
        public List<AnswerDTO> GetCorrectByTestId(int testId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Answer_GetCorrectByTestID";
            return connection.Query<AnswerDTO>(sqlExpression, new { testId }, commandType: CommandType.StoredProcedure).ToList();
        }

        public void Update(AnswerDTO answer)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Answer_UpdateAll";
            connection.Execute(sqlExpression, answer, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Answer_DeleteById";
            connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
        }
    }
}
