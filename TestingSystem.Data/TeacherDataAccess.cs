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
                
        public List<GroupDTO> GetGroupsAndStudentsByTeacherId(int teacherId) // уничтожили GetGroupByTeacherID. в группе создать свойство листюзеров 
        {
           UserManager teacher = new UserManager();
           return teacher.GetGroupsAndStudentsByTeacherID(teacherId);
        }

        public List<QuestionAnswerDTO> GetCorrectAnswerByTestId(int testId)
        {
            TestManager teacher = new TestManager();
            return teacher.GetCorrectAnswerByTestID(testId);

        } //  в идеаде - один то мэни - почитать


     
        public List<TestDTO> GetTestByGroupId(int groupId) //!!!!!!!
        {
            TestManager teacher = new TestManager();
            return teacher.GetTestByGroupId(groupId);
        }

        public List<AllStudentTestsDTO> GetAllStudentTests(int id) // конкретные студент - лучшая попытка и макс балл. GetAllTestsByUserID

        {
            UserManager teacher = new UserManager();
            return teacher.GetStudentVsTests(id);
        }

        public List<TestDTO> GetExpiredTestOfStudent(int userId)// на вход надо user id
        {
            TestManager teacher = new TestManager();
            return teacher.GetLateAttempt(userId);
        }
        
        public List<TestAttemptDTO> GetStudentIncompleteTests(int id) // не приступал
        {
            UserManager teacher = new UserManager();
            return teacher.GetIncompleteTests(id);
        }

        public List<QuestionAnswerDTO> GetQuestionAndAnswerByAttempt(int attemptId) // один ко многим

        {
            TestManager teacher = new TestManager();
            return teacher.GetQuestionAndAnswerFromAttempt( attemptId);

        }

        public List<AllStudentTestsDTO> GetBestResultOfTestByGroupId(int groupId) //Лучшая попытка конкретного теста конкретного юзера -  все студенты *
        {
            TestManager teacher = new TestManager();
            return teacher.GetBestResultOfTestByGroupID(groupId);
        }
      
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

        public List<TestDTO> GetTestVSTagSearchOr(params string[] tag)
        {
            TestManager teacher = new TestManager();
            return teacher.GetTestVSTagSearchOr(tag);

        }

        public List<TestDTO> GetTestVSTagSearchAnd(params string[] tag)
        {
            TestManager teacher = new TestManager();
            return teacher.GetTestVSTagSearchAnd(tag);

        }
        public List<TestDTO> GetTestByTagIdGroupId(TagGroupDTO dto) //корректный
                                                                        
        {
            TestManager teacher = new TestManager();
            return teacher.GetTestByTagpAndGroup(dto);

        }
                
        public int DeleteConcreteAttempt(AttemptDTO attempt)  //  метод - удалить конкретного попытку конкретного студента
        {
            TestManager teacher = new TestManager();
            return teacher.DeleteConcreteAttempt(attempt);

        }

        public void DeleteTestByGroupId(int id) //  метод - убрать тест у группы
        {
            TestGroupCRUD testdeletion = new TestGroupCRUD();
            testdeletion.DeleteByTestId(id);
        }

       
        public void SetTestForGroup(TestGroupDTO testgroup)   // метод - назначить тест - записать из круда
        {
            TestGroupCRUD teacher = new TestGroupCRUD();
            teacher.Add(testgroup);
        }
        public List<QuestionAnswerDTO> GetAllAnswerByAttemptId(int attemptId)
        {
            AttemptManager b = new AttemptManager();
            return b.GetAllAnswersByAttemptId(attemptId);
        }
    }
}