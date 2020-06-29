using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class AttemptResultDTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GroupName { get; set; }
        public DateTime Datetime { get; set; }
        public TimeSpan Duration { get; set; }
        public int Number { get; set; }
        public int Result { get; set; }
        public string Status { get; set; }

        public AttemptResultDTO()
        {
        }
        
        public AttemptResultDTO(int UserID, string FirstName, string LastName, string GroupName, DateTime Datetime, TimeSpan Duration, int Number, int Result, string Status)
        {
            this.UserID = UserID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.GroupName = GroupName;
            this.Number = Number;
            this.Result = Result;
            this.Status = Status;
        }
    }
}