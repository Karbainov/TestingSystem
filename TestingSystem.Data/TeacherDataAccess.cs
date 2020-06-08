using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Data;
using TestingSystem.Data.DTO;
using Dapper;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.StoredProcedure.CRUD;

namespace TestingSystem.Data
{
    public class TeacherDataAccess
    {

       // уничтожить GetGroupByTeacherID. в группе создать свойство листюзеров 

        //public List<UserDTO> GetGroupsAndStudentsByTeacherID(int id)
        //{
        //    GroupManager teacher = new GroupManager();
        //    return teacher.GetAllStudents(id);
        //}
               
        public List<QuestionAnswerDTO> GetCorrectAnswerByTestID(int testID)
        {
            TestManager teacher = new TestManager();
            return teacher.GetCorrectAnswerByTestID(testID);

        } //  в идеаде - один то мэни - почитать

        public List<TestDTO> GetTestByGroupId(int GroupID)
        {
            TestManager teacher = new TestManager();
            return teacher.GetTestByGroupId(GroupID);
        }

        public List<AllStudentTestsDTO> GetAllStudentTests(int id) // конкретные студент - лучшая попытка и макс балл. GetAllTestsByUserID

        {
            UserManager teacher = new UserManager();
            return teacher.GetStudentVsTests(id);
        }

        public List<TestDTO> GetExpiredTestOfStudent(int userID)// на вход надо user id
        {
            TestManager teacher = new TestManager();
            return teacher.GetLateAttempt(userID);
        }
        
        public List<TestAttemptDTO> GetStudentIncompleteTests(int id) // не приступал
        {
            UserManager teacher = new UserManager();
            return teacher.GetIncompleteTests(id);
        }

        public List<QuestionAnswerDTO> GetQuestionAndAnswerByAttempt(int attemptID) // один ко многим

        {
            TestManager teacher = new TestManager();
            return teacher.GetQuestionAndAnswerFromAttempt( attemptID);

        }
        //Лучшая попытка конкретного теста конкретного юзера -  все студенты *

   
        public List<AttemptResultDTO> GetBestResultsOfStudentsByTestId(int testId) //Лучшие Результаты всех студентов для тестов группы 
        {
            AttemptManager teacher = new AttemptManager();
            return teacher.GetBestResultsOfStudentsByTestId(testId);

        }


        public List<AttemptResultDTO> GetAttemptsByUserIdTestId(UserIdTestIdDTO attempt)
        {
            AttemptManager teacher = new AttemptManager();
            return teacher.GetAttemptByUserIdTestId(attempt);

        }

        public List<SearchTestByTagDTO> GetTestVSTagSearchOr(string tag1, string tag2, string tag3)
        {
            TestManager teacher = new TestManager();
            return teacher.GetTestVSTagSearchOr(tag1, tag2, tag3);

        }// поговорить со Славой после исправления (null, default)

        public List<SearchTestByTagDTO> GetTestVSTagSearchAnd(string tag1, string tag2, string tag3)
        {
            TestManager teacher = new TestManager();
            return teacher.GetTestVSTagSearchAnd(tag1, tag2, tag3);

        }
        public List<TestDTO> GetTestByTagpAndGroup(TagGroupDTO dto) //нужно передать название tag + integer GroupID 
                                                                        
        {
            TestManager teacher = new TestManager();
            return teacher.GetTestByTagpAndGroup(dto);

        }
                
        public int DeleteConcreteAttempt(AttemptDTO attempt)  // добавить метод - удалить конкретного попытку конкретного студента
        {
            TestManager teacher = new TestManager();
            return teacher.DeleteConcreteAttempt(attempt);

        }

        public void DeleteTestByGroupId(int id) // добавить метод - убрать тест у группы
        {
            TestGroupCRUD testdeletion = new TestGroupCRUD();
            testdeletion.DeleteByTestId(id);
        }

       
        public void SetTestForGroup(TestGroupDTO testgroup)   // добавить метод - назначить тест - записать из круда
        {
            TestGroupCRUD teacher = new TestGroupCRUD();
            teacher.Add(testgroup);
        }
        
    }
}