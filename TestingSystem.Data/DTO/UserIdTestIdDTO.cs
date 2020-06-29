using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class UserIdTestIdDTO
    {
        public int UserID { get; set; }
        public int TestID { get; set; }

        public UserIdTestIdDTO()
        {
        }

        public UserIdTestIdDTO(int userID, int testID)
        {           
            UserID = userID;
            TestID = testID;            
        }       
    }
}
