using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class UserTestWithQuestionsAndAnswersDTO
    {

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumAttempt { get; set; }
        public int Result { get; set; }
        public int SuccessScore { get; set; }
        public string TestName { get; set; }
        public int TestID { get; set; }

        public List<QuestionWithAnswersDTO> Questions { get; set; }
        
    }
}
