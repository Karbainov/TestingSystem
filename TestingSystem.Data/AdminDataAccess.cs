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
            
            UserCRUD user = new UserCRUD();
            user.Create(userC);
        }
        public void UserUpdate(UserDTO userU)
        {
            
            UserCRUD user = new UserCRUD();
            user.Update( userU);
        }
        public void UserDelete(UserDTO userD)
        {
            
            UserCRUD user = new UserCRUD();
            user.Create( userD);
        }
        public void GroupCreate(GroupDTO groupC)
        {
            GroupCRUD group = new GroupCRUD();
            group.Add(groupC);
        }
        public void GroupUpdate(GroupDTO groupU)
        {
            GroupCRUD group = new GroupCRUD();
            group.Update(groupU);
        }
        public void Delete(int id)
        {
            GroupCRUD group = new GroupCRUD();
            group.Delete(id);
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
        public void AddRoleToUser(UserRoleDTO dTO)
        {
            UserRoleCRUD roleCRUD = new UserRoleCRUD();
            roleCRUD.Create(dTO);
        }
        public List<UserRoleDTO> GetAllUserRoles()
        {
            UserRoleCRUD roleCRUD = new UserRoleCRUD();
            return roleCRUD.Read();
        }
        public List<UserRoleDTO> GetUserRolesByUserID(int userID)
        {
            UserRoleCRUD roleCRUD = new UserRoleCRUD();
            return roleCRUD.ReadByUserID(userID);
        }
        public List<UserRoleDTO> GetUserRolesByRoleID(int roleID)
        {
            UserRoleCRUD roleCRUD = new UserRoleCRUD();
            return roleCRUD.ReadByRoleID(roleID);
        }
        public void DeliteUsersRole(UserRoleDTO userRoleDTO)
        {
            UserRoleCRUD roleCRUD = new UserRoleCRUD();
            roleCRUD.Delete(userRoleDTO);
        }
       
        public List<RoleDTO> GetRole()
        {
            RoleCRUD role = new RoleCRUD();
            return role.Read();
        }
    }
}
