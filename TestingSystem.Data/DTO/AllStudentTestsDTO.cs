using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class AllStudentTestsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameTest { get; set; }
        public int NumberOfAttempts { get; set; }
        public int MaxResult { get; set; }


        public AllStudentTestsDTO() { }

        public AllStudentTestsDTO(int userId, string firstName, string lastName, string nameTest, int numberOfAttempts, int maxResult)
        {
            this.Id = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NameTest = nameTest;
            this.NumberOfAttempts = numberOfAttempts;
            this.MaxResult = maxResult;

        }
    }
}
