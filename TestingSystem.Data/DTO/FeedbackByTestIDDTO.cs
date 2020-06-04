using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    class FeedbackByTestIDDTO
    {
        public int testID { get; set; }
        public string message { get; set; }
        public string value { get; set; }

        public FeedbackByTestIDDTO()
        {
        }

        public FeedbackByTestIDDTO(int TestID)
        {
            this.testID = testID;

        }
    

    }
}
