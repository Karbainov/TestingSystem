using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure.CRUD;

namespace TestingSystem.Data
{
    public class AdminDataAccess
    {
        public void UserCreate(UserDTO userC)
        {
            var connect = Connection.GetSqlConnection();
            User user = new User();
            user.User_Create(connect, userC);
        }
        public void UserUpdate(UserDTO userU)
        {
            var connect = Connection.GetSqlConnection();
            User user = new User();
            user.User_Update(connect, userU);
        }
        public void UserDelete(UserDTO userD)
        {
            var connect = Connection.GetSqlConnection();
            User user = new User();
            user.User_Create(connect, userD);
        }
        public void GroupCreate(GroupDTO groupC)
        {
            Group group = new Group();
            group.GroupAdd(groupC);
        }
        public void GroupUpdate(GroupDTO groupU)
        {
            Group group = new Group();
            group.GroupUpdate(groupU);
        }
        public void GroupDelete(GroupDTO groupD)
        {
            Group group = new Group();
            group.GroupAdd(groupD);
        }
        public void StudentAdd (Student_GroupDTO studentA) 
        {
            Student_Group student = new Student_Group();
            student.StudentGroupAdd(studentA);
        }
        public void StudentDelete(Student_GroupDTO studentD)
        {
            Student_Group student = new Student_Group();
            student.StudentGroupDeleteByID(studentD.ID);
        }
        public void TeacherAdd(Teacher_GroupDTO teacherA)
        {
            Teacher_Group student = new Teacher_Group();
            student.TeacherGroupAdd(teacherA);
        }
        public void TeacherDelete(Teacher_GroupDTO teacherD)
        {
            Teacher_Group student = new Teacher_Group();
            student.TeacherGroupDeleteByID(teacherD.ID);
        }
    }
}
