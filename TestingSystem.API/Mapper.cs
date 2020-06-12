using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingSystem.API.Models.Output;
using TestingSystem.Data.DTO;
using TestingSystem.Data;

namespace TestingSystem.API
{
    public class Mapper
    {
        public TestModel TestDTOToTestModel(TestDTO testDTO)
        {
            return new TestModel()
            {
                Id = testDTO.ID,
                Name = testDTO.Name,
                SuccessScore = testDTO.SuccessScore,
                DurationTime = testDTO.DurationTime,
            };
        }

        public List<TestModel> TestDTOToTestModelList(List<TestDTO> dtoList)
        {
            List<TestModel> modelList = new List<TestModel>();
            foreach(TestDTO testDTO in dtoList)
            {
                modelList.Add(TestDTOToTestModel(testDTO));
            }
            return modelList;
        }
        
        // все для группМодел
        // UserWithRoleDTO превращаем в список teachers
                
        public TeacherModel UserWithRoleDTOToTeacherModel(UserWithRoleDTO teachers)
        {
            return new TeacherModel()
            {
                ID = teachers.ID,
                FirstName = teachers.FirstName,
                LastName = teachers.LastName,
                BirthDate = teachers.BirthDate,
                Login = teachers.Login,
                Password = teachers.Password,
                Email = teachers.Email,
                Phone = teachers.Phone,
                RoleID = teachers.RoleID,

            };
        }

        public List<TeacherModel> UserWithRoleDTOToTeacherModelList(List<UserWithRoleDTO> dtList)
        {
            List<TeacherModel> modelteacherList = new List<TeacherModel>();
            foreach (UserWithRoleDTO teachers in dtList)
            {
                modelteacherList.Add(UserWithRoleDTOToTeacherModel(teachers));
            }
            return modelteacherList;
        }
        public StudentModel UserGroupDTOToStudentModel(UserGroupDTO students)
        {
            return new StudentModel
            {
                ID = students.ID,
                FirstName = students.FirstName,
                LastName = students.LastName,
                BirthDate = students.BirthDate,
                Login = students.Login,
                Password = students.Password,
                Email = students.Email,
                Phone = students.Phone,
                GroupID = students.GroupID,

            };
        }
        public List<StudentModel> UserGroupDTOToStudentModelList(List<UserGroupDTO> Listok)
        {
            List<StudentModel> modelstudentList = new List<StudentModel>();
            foreach (UserGroupDTO students in Listok)
            {
                modelstudentList.Add(UserGroupDTOToStudentModel(students));
            }
            return modelstudentList;
        }
        public GroupOutputModel UserGroupDTOUserWithRoleDTOGroupToGroupOutputModelModel(List <UserGroupDTO> st, List <UserWithRoleDTO> t, GroupNewDTO g)
        {
            return new GroupOutputModel
            {
                Id = g.Id,
                Name = g.Name,
                StartDate = g.StartDate,
                EndDate = g.EndDate,
                List <StudentModel> students = new List<StudentModel>();
                students.UserGroupDTOToStudentModelList(st),
                List<TeacherModel> teachers = new List<TeacherModel>();
                teachers.UserWithRoleDTOToTeacherModelList(t);
             };
        }

    }

