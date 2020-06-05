using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.StoredProcedure.CRUD;

namespace TestingSystem.Data
{
    public class StudentDataAccess
    {
        public void CreateFeedback(FeedbackDTO feedbackDTO)
        {
            FeedbackCRUD feedback = new FeedbackCRUD();
            feedback.FeedbackAdd(feedbackDTO);
        }
        public List<TestAttemptDTO> GetCompleteTest(int userID)
        {
            TestManager manager = new TestManager();
            return manager.GetCompletedTestsByUserID(userID);
        }
        public List<TestAttemptDTO> GetIncompleteTest(int userID)
        {
            UserManager user = new UserManager();
            return user.GetIncompleteTests(userID);
        }
        public List<AllStudentTestsDTO> GetAllStudentTests(int userID)
        {
            UserManager user = new UserManager();
            return user.GetStudentVsTests(userID);
        }
       
    }
}
