using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Data.StoredProcedure.CRUD;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.DTO;
using TestingSystem.Data;

namespace TestingSystem.Business.Models
{
    public class AttemptBusinessModel
    {
        int AttemptId { get; set; }
        public string TestName { get; set; }
        public TimeSpan?  DurationTime { get; set; }

        List<QuestionWithListAnswersDTO> Questions;


        public AttemptBusinessModel()
        {
            
        }

        public AttemptBusinessModel(int attemptId, string testName, TimeSpan? durationTime, List<QuestionWithListAnswersDTO> questions)
        {

            AttemptId = attemptId;
            TestName = testName;
            DurationTime = durationTime;
            Questions = questions;
        }
    }
}
