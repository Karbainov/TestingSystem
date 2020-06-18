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
        public int AddAttempt(AttemptDTO dto)
        {
            AttemptCRUD attempt = new AttemptCRUD();
            return attempt.AttemptAdd(dto);
        }
        public int AddAnswerToQuestion(AttemptQuestionAnswerDTO dto)
        {
            AttemptQuestionAnswerCRUD attemptQuestionAnswer = new AttemptQuestionAnswerCRUD();
            return attemptQuestionAnswer.Add(dto);
        }
        public int AddAnswer(AnswerDTO dto)
        {
            AnswerCRUD answer = new AnswerCRUD();
            return answer.AnswerAdd(dto);
        }
        public List<QuestionDTO> GetQuestionsFromTest(int id)
        {
            QuestionManager manager = new QuestionManager();
            return manager.GetQuestionsByTestID(id);
        }
        public List<AttemptResultDTO> GetAttemptsByUserIdTestId(UserIdTestIdDTO attempt)
        {
            AttemptManager teacher = new AttemptManager();
            return teacher.GetAttemptByUserIdTestId(attempt);

        }
        public UserDTO GetUser(int id)
        {
            UserCRUD user = new UserCRUD();
            return user.GetByID(id);
        }

        public List<QuestionWithListAnswersDTO> GetQuestionsAndAnswers(int testID)
        {
            QuestionManager test = new QuestionManager();
            return test.GetQuestionsAndAnswers(testID);

        }

        public TestDTO GetTestWithDurationAndQuestionNumber(int id)
        {
            TestManager test = new TestManager();
            return test.GetTestWithDurationAndQuestionNumber(id);

        }

        public int AddAttemptForAttemptCreator(int userId, int testId)
        {
            AttemptDTO attempt = new AttemptDTO()
            {
                userID = userId,
                testID = testId,
                dateTime = DateTime.Now

            };
            AttemptManager student = new AttemptManager();
            return student.AddAttemptAutoNumber(attempt);


        }
    }
}
