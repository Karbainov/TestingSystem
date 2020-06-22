using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class AttemptQuestionAnswerFullInfoManager
    {
        public List<AttemptQuestionAnswerFullInformationDTO> GetByTestId(int testId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "QuestionAnswerFullInformation_TestID";
            return connection.Query<AttemptQuestionAnswerFullInformationDTO>(sqlExpression, new { testId }, commandType: CommandType.StoredProcedure).ToList();
        }
        public List<AttemptQuestionAnswerFullInformationDTO> GetByGroupId(int groupId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "QuestionAnswerFullInformation_GroupID";
            return connection.Query<AttemptQuestionAnswerFullInformationDTO>(sqlExpression, new { groupId }, commandType: CommandType.StoredProcedure).ToList();
        }
        public List<AttemptQuestionAnswerFullInformationDTO> GetByQuestionId(int questionId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "QuestionAnswerFullInformation_QuestionID";
            return connection.Query<AttemptQuestionAnswerFullInformationDTO>(sqlExpression, new { questionId }, commandType: CommandType.StoredProcedure).ToList();
        }
        public List<AttemptQuestionAnswerFullInformationDTO> GetByUserId(int userId)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "QuestionAnswerFullInformation_UserID";
            return connection.Query<AttemptQuestionAnswerFullInformationDTO>(sqlExpression, new { userId }, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
