using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.DTO;
using System.Data.SqlClient;
using System.Linq;

namespace TestingSystem.Data
{
    public class TeacherDataAccess
    {

        public List<GroupDTO> GetGroupByTeacherID(UserDTO user)
        {
            GroupManager teacher = new GroupManager();
            SqlConnection connection = (SqlConnection)Connection.GetConnection();
            return teacher.Group_GetByTeacherID(connection, user);

        }

        /* public List<UserDTO> GetStudentsFromGroup(int id)
         {
             StudentsFromGroupGetter teacher = new StudentsFromGroupGetter();
             return teacher.GetStudentsFromGroup(id);

         }*/

        ///  Select Вопросы теста 
        ///  


        //public List<Question_AnswerDTO> GetCorrectAnswerByTestID(TestDTO test)
        //{
        //    TestManager teacher = new TestManager();
        //    SqlConnection connection = (SqlConnection)Connection.GetConnection();
        //    return teacher.AnswerGetCorrectByTestID(connection, test);

        //}

        ///// Select Тесты группы
        ///// 

        //public List<AllStudentTestsDTO> GetAllStudentTests(int id)
        //{
        //    AllStudentTest teacher = new AllStudentTest();
        //    return teacher.AllStudentTests(id);

        //}


        //public List<TestDTO> GetExpiredTestOfStudent(UserDTO user)
        //{
        //    TestManager teacher = new TestManager();
        //    SqlConnection connection = (SqlConnection)Connection.GetConnection();
        //    return teacher.Test_Attempt_GetLate(connection, user);

        //}

        //public List<FeedbackByTestIDDTO> GetFeedbackByTestID(FeedbackByTestIDDTO feedback)
        //{
        //    GetFeedbackByTestID teacher = new GetFeedbackByTestID();
        //    return teacher.GetFeedbackByTestID(feedback);

        //}


        /*public List<TestAttemptDTO> GetStudentIncompleteTests(int id)
        {
            StudentIncompleteTestsGetter teacher = new StudentIncompleteTestsGetter();
            return teacher.GetStudentIncompleteTests(id);

        }*/
        //SelectОтветы на вопросы попытки

        //Лучшая попытка конкретного теста конкретного юзера
        //Лучшие Результаты всех студентов для тестов группы
        //Лучшие Результаты всех студентов для теста


        //public List<AttemptResultDTO> GetAllAttemptsByUserIdTestId(UserIdTestIdForAttemptDTO attempt)
        //{
        //    AttemptByUserTest teacher = new AttemptByUserTest();
        //    return teacher.AttemptGetByUserIdTestId(attempt);

        //}
    }
}