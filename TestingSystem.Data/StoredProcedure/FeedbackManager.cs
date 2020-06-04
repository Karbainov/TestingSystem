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

        public List<FeedbackByDateDTO> GetFeedbackByDate(DateTime dateTime1, DateTime dateTime2)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "GetFeedbackByDateTime";
                return connection.Query<FeedbackByDateDTO>(sqlExpression, new { dateTime1, dateTime2 }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<FeedbackQuestionDTO> GetFeedbackAndQuestionByUserDate(UserIdDateIdDTO feedback)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "FeedBackQuestion_GetByUserDate";
            return connection.Query<FeedbackQuestionDTO>(sqlExpression, feedback, commandType: CommandType.StoredProcedure).ToList();           
        }
    }
}
