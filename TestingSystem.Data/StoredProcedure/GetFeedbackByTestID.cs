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
    class GetFeedbackByTestID
    {

        public GetFeedbackByTestID()
        {
        }

        public List<FeedbackByTestIDDTO> GetFeedbackByTest(FeedbackByTestIDDTO feedback)
        {
            var connection = Connection.GetConnection();
            string sqlExpression = "GetTestFeedback";
            List<FeedbackByTestIDDTO> fb = new List<FeedbackByTestIDDTO>();
            fb = connection.Query<FeedbackByTestIDDTO>(sqlExpression, feedback, commandType: CommandType.StoredProcedure).ToList();
            return fb;
        }
    }
}
