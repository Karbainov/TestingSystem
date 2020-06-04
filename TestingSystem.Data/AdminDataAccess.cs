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
        public void StudentAdd (StudentGroupDTO studentA) 
        {
            StudentGroup student = new StudentGroup();
            student.Add(studentA);
        }
        public void StudentDelete(StudentGroupDTO studentD)
        {
            StudentGroup student = new StudentGroup();
            student.DeleteByID(studentD.ID);
        }
        public void TeacherAdd(TeacherGroupDTO teacherA)
        {
            TeacherGroup student = new TeacherGroup();
            student.Add(teacherA);
        }
        public void TeacherDelete(TeacherGroupDTO teacherD)
        {
            TeacherGroup student = new TeacherGroup();
            student.DeleteByID(teacherD.ID);
        }
    }
}
