using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class StudentsVSTestsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int NumberOfAttempts { get; set; }
        public int MaxResult { get; set; }


        public StudentsVSTestsDTO() { }

        public StudentsVSTestsDTO(int userId, string firstName,int testId , string lastName, string testName, int numberOfAttempts, int maxResult)
        {
            this.Id = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.TestId = testId;
            this.TestName = testName;
            this.NumberOfAttempts = numberOfAttempts;
            this.MaxResult = maxResult;

        }
    }
}
