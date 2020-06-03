using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class AllStudentTestsDTO
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nameTest { get; set; }
        public int numberOfAttempts { get; set; }
        public int maxResult { get; set; }


        public AllStudentTestsDTO() { }

        public AllStudentTestsDTO(int userId, string firstName, string lastName, string nameTest, int numberOfAttempts, int maxResult)
        {
            this.Id = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.nameTest = nameTest;
            this.numberOfAttempts = numberOfAttempts;
            this.maxResult = maxResult;

        }
    }
}
