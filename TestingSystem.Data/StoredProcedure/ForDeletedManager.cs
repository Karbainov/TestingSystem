using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class ForDeletedManager
    {
        public List<UserDTO> GetDeletedUsers()
        {
            using(var connection = Connection.GetConnection())
            {
                string sqlExpression = "User_GetDeleted";
                return connection.Query<UserDTO>(sqlExpression).ToList();
            }
        }

        public int RestoreUser(int id)
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Restore @id";
                return connection.Query<int>(sqlExpression, new { id }).FirstOrDefault();
            }
        }
        
        public int RestoreTest(int id)
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "Test_Restore @id";
                return connection.Query<int>(sqlExpression, new { id }).FirstOrDefault();
            }
        }
        public List<QuestionDTO> GetDeletedQuestions()
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "Question_GetDeleted";
                return connection.Query<QuestionDTO>(sqlExpression).ToList();
            }
        }
        public int RestoreQuestion(int id)
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "Question_Restore @id";
                return connection.Query<int>(sqlExpression, new { id }).FirstOrDefault();
            }
        }
        public List<GroupDTO> GetDeletedGroups()
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_GetDeleted";
                return connection.Query<GroupDTO>(sqlExpression).ToList();
            }
        }
        public int RestoreGroup(int id)
        {
            using (var connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_Restore @id";
                return connection.Query<int>(sqlExpression, new { id }).FirstOrDefault();
            }
        }
        public List<TestQuestionTagDTO> GetDeletedOneToManyTests()
        {
            using(var connection = Connection.GetConnection())
            {
                List<TestQuestionTagDTO> dTOs;
                var TestDictionary = new Dictionary<int, TestQuestionTagDTO>();
                string sqlExpression = "GetdeletedTests";
                    connection.Query <TestQuestionTagDTO, QuestionForOneToManyDTO, TagWithTestIDDTO, TestQuestionTagDTO>(sqlExpression, ( test , question , tag )=>
                    {
                    TestQuestionTagDTO testEntry;
                    if(!TestDictionary.TryGetValue(test.ID,out testEntry))
                    {
                        testEntry = test;
                        testEntry.Questions = new List<QuestionForOneToManyDTO>();
                        testEntry.Questions.Add(question);
                        testEntry.Tags = new List<TagWithTestIDDTO>();
                        TestDictionary.Add(testEntry.ID, testEntry);
                    }
                    testEntry.Tags.Add(tag);
                    return testEntry;
                    }
                ,splitOn:"TestID,IDtest" ).ToList();
                dTOs = new List<TestQuestionTagDTO>(TestDictionary.Values);
                return dTOs;
            }
        }
        public List<GroupWithStudentsAndTeachersDTO> GetDeletedGroupsOneToMany()
        {
            using (var connection = Connection.GetConnection())
            {
                 List<GroupWithStudentsAndTeachersDTO> result = new List<GroupWithStudentsAndTeachersDTO>();
                GroupWithStudentsAndTeachersDTO one = new GroupWithStudentsAndTeachersDTO() ;
                string sqlExpression = "GetDeletedGroupsWithStudentsAndTeachers";
                connection.Query<GroupWithStudentsAndTeachersDTO, StudentDTO, TeacherDTO, GroupWithStudentsAndTeachersDTO>(sqlExpression, (group, student, teacher) =>
                   {
                       if ( !result.Any(x => x.Id == group.Id))
                       {
                           one = group;
                           one.students = new List<StudentDTO>();
                           one.students.Add(student);
                           one.teachers = new List<TeacherDTO>();
                           one.teachers.Add(teacher);
                           result.Add(one);
                       }
                       if (result.Any(x => x.Id == group.Id))
                       {
                           int id = result.FindIndex(x => x.Id == group.Id);
                           if (!result.Any(x => x.students.Any(y =>y!=null&& y.StudentID == student.StudentID)))
                           {
                               result[id].students.Add(student);
                           }
                           if (!result.Any(x => x.teachers.Any(y => y != null && y.TeacherID == teacher.TeacherID)))
                           {
                               result[id].teachers.Add(teacher);
                           }
                       }
                       return one;
                   }, splitOn: "IDGroup,GroupID"
                );
                return result;
            }
        }
    }
}
