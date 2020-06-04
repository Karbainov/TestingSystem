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
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Value { get; set; }
        public bool Correct { get; set; }
        public AnswerCRUD()
        {
        }

        public int AnswerAdd(AnswerDTO answer)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "Answer_Add @questionID, @value, @correct";
            int answerID = connection.Query<int>(sqlExpression, answer).FirstOrDefault();
            answer.ID = answerID;
            return answer.ID;
        }

        public List<AnswerDTO> GetAll()
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Answer_GetAll";
            List<AnswerDTO> answer = new List<AnswerDTO>();
            answer = connection.Query<AnswerDTO>(sqlExpression).ToList();
            return answer;
        }

        public AnswerDTO GetById(int id)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Answer_GetById";
            AnswerDTO newAnswer = null;
            newAnswer = connection.Query<AnswerDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return newAnswer;
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

        public List<AnswerDTO> AnswerGetByQuestionId(int questionID)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Answer_GetByQuestionID";
            return connection.Query<AnswerDTO>(sqlExpression, new { questionID }, commandType: CommandType.StoredProcedure).ToList();
        }
        
        public List<AnswerDTO> AnswerGetCorrectByTestID(int testID)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "Answer_GetCorrectByTestID";
            return connection.Query<AnswerDTO>(sqlExpression, new { testID }, commandType: CommandType.StoredProcedure).ToList();
        }

    }
}
