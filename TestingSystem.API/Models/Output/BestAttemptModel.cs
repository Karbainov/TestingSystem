using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class BestAttemptModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfAttempt { get; set; }
        public int Result { get; set; }
        public int SuccessScore { get; set; }
        public string TestName { get; set; }
        public int TestID { get; set; }

        public List<QuestionOutputModel> Questions { get; set; }
    }
}
