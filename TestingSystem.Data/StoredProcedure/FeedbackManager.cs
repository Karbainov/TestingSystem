using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TestingSystem.Data.DTO;
using Dapper;
using System.Linq;

namespace TestingSystem.Data.StoredProcedure
{
    public class FeedbackManager
    {
        public List<FeedbackSortByDataTimeDTO> feedbackSortByDataTime (QuestionDTO question) 
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Feedback_SortByDataTime @QuestionID";
                return connection.Query<FeedbackSortByDataTimeDTO>(sqlExpression, new { question.ID }, commandType: CommandType.StoredProcedure).ToList();
            }

        }
    }
}
