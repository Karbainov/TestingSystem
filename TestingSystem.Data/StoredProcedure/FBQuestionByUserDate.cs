using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class FBQuestionByUserDate
    {
        public FBQuestionByUserDate()
        {
        }

        public FeedbackQuestionDTO FBQuestionGetByUserId(UserIdDateForFeedbackDTO feedback)
        {
            var connection = Connection.GetConnection();            
            string sqlExpression = "FeedBackQuestion_GetByUserDate";
            FeedbackQuestionDTO feedbacks = new FeedbackQuestionDTO();
            feedbacks = connection.Query<FeedbackQuestionDTO>(sqlExpression, feedback, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return feedbacks;
        }
    }
}
