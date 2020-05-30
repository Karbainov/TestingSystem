using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class AttemptDBO
    {
        public int id { get; set; }
        public int number { get; set; }
        public int userID { get; set; }
        public int testID { get; set; }
        public int userResult { get; set; }
        public DateTime dateTime { get; set; }
        public TimeSpan durationTime { get; set; }
        public AttemptDBO(int _id,int _number,int _userID, int _testID,int _userResult,DateTime _dateTime,TimeSpan _durationTime)
        {
            id = _id;
            number = _number;
            userID = _userID;
            testID = _testID;
            userResult = _userResult;
            dateTime = _dateTime;
            durationTime = _durationTime;
        }
        public AttemptDBO()
        { 
        }

        public AttemptDBO(int _userID, int _testID)
        {
            userID = _userID;
            testID = _testID;
        }
    }
}
