using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class UserIdTestIdForAttemptDTO
    {
        public int UserID { get; set; }
        public int TestID { get; set; }

        public UserIdTestIdForAttemptDTO()
        {
        }

        public UserIdTestIdForAttemptDTO(int userID, int testID)
        {           
            UserID = userID;
            TestID = testID;            
        }       
    }
}
