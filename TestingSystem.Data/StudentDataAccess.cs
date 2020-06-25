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
            feedback.Add(feedbackDTO);
        }
        public List<TestAttemptDTO> GetCompleteTests(int userId)
        {
            TestManager manager = new TestManager();
            return manager.GetCompletedTestsByUserID(userId);
        }
        public List<TestAttemptDTO> GetIncompleteTests(int userId)
        {
            UserManager user = new UserManager();
            return user.GetIncompleteTests(userId);
        }
        public List<AllStudentTestsDTO> GetStudentsTests(int userId)
        {
            UserManager user = new UserManager();
            return user.GetStudentVsTests(userId);
        }
        public int AddAttempt(AttemptDTO dto)
        {
            AttemptCRUD attempt = new AttemptCRUD();
            return attempt.Add(dto);
        }
        public int AddAnswerToQuestion(AttemptQuestionAnswerDTO dto)
        {
            AttemptQuestionAnswerCRUD attemptQuestionAnswer = new AttemptQuestionAnswerCRUD();
            return attemptQuestionAnswer.Add(dto);
        }
        public int AddAnswer(AnswerDTO dto)
        {
            AnswerCRUD answer = new AnswerCRUD();
            return answer.Add(dto);
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


        public int AddAttemptAutoNumber(AttemptDTO attempt)
        {
            AttemptManager newattempt = new AttemptManager();
            return newattempt.AddAttemptAutoNumber(attempt);
        }

        public void AddQuestionToAttempt(int attemptId, int questionId)
        {
            AttemptManager newattempt = new AttemptManager();
            newattempt.AddQuestionToAttempt(attemptId, questionId);
        }

        public TestDTO GetTestById(int testId)
        {
            TestManager test = new TestManager();
            return test.GetDurationAndQuestionNumber(testId);
        }

        public List<QuestionWithListAnswersDTO> GetQuestionsAndAnswers(int testId)
        {
            TestManager test = new TestManager();
            return test.GetQuestionsAndAnswers(testId);
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
        
        public void DeleteAttemptQuestionAnswerByAttemptId(int attemptId)
        {
            AttemptQuestionAnswerCRUD student = new AttemptQuestionAnswerCRUD();
            student.DeleteByAttemptId(attemptId);
        }
        
        public void AddAttemptQuestionAnswer(int attemptId, int questionId, int answerId)
        {
            AttemptQuestionAnswerCRUD student = new AttemptQuestionAnswerCRUD();
            student.Add(new AttemptQuestionAnswerDTO(0, attemptId, questionId, answerId));
        }

        public QuestionTypeAnswersDTO GetQuestionTypeIdCorrectAnswerByQuestionId(int questionId)
        {
            QuestionManager student = new QuestionManager();
            return student.GetQuestionTypeIdCorrectAnswerByQuestionId(questionId);
        }

        public int GetQtyOfAnswersInAttempt(int attemptId)
        {
            AttemptManager student = new AttemptManager();
            return student.GetQtyOfAnswersInAttempt(attemptId);
        }
    }
}
