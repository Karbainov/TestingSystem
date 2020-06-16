using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure.CRUD;
using TestingSystem.Data.StoredProcedure;

namespace TestingSystem.Data
{
    public class AdminDataAccess
    {
        public void UserCreate(UserDTO userC)
        {
            
            UserCRUD user = new UserCRUD();
            user.Create(userC);
        }

        public List<UserDTO> GetAllUsers()
        {

            UserCRUD user = new UserCRUD();
            return user.GetAll();
        }
        public UserDTO GetUserbyID (int id)
        {
            UserCRUD user = new UserCRUD();
            return user.GetByID(id);
        }

        public void UserUpdate(UserDTO userU)
        {
            
            UserCRUD user = new UserCRUD();
            user.Update( userU);
        }
        public void UserDelete(int id)
        {
            UserCRUD user = new UserCRUD();
            user.Delete(id);
        }
        public void GroupCreate(GroupDTO groupC)
        {
            GroupCRUD group = new GroupCRUD();
            group.Add(groupC);
        }

        public List<GroupDTO> GetAllGroups()
        {
            GroupCRUD group = new GroupCRUD();
            return group.GetAll();  
        }

        public GroupDTO GetGroupById(int id)
        {
            GroupCRUD group = new GroupCRUD();
            return group.GetById(id);  
        }

        public void GroupUpdate(GroupDTO groupU)
        {
            GroupCRUD group = new GroupCRUD();
            group.Update(groupU);
        }
        public void GroupDelete(int id)   // скорректировала название Горина
        {
            GroupCRUD group = new GroupCRUD();
            group.Delete(id);
        }
        public void StudentAdd (int userID, int groupID) 
        {
            StudentGroupDTO studentA = new StudentGroupDTO(1, userID, groupID);
            StudentGroup student = new StudentGroup();
            student.Add(studentA);
        }
        public void StudentDelete(StudentGroupDTO studentD)
        {
            StudentGroup student = new StudentGroup();
            student.DeleteByID(studentD.ID);
        }
        public void TeacherAdd(int userID, int groupID)
        {
            TeacherGroupDTO teacherA = new TeacherGroupDTO(1, userID, groupID);
            TeacherGroup teacher = new TeacherGroup();
            teacher.Add(teacherA);
        }
        public void TeacherDelete(TeacherGroupDTO teacherD)
        {
            TeacherGroup teacher = new TeacherGroup();
            teacher.DeleteByID(teacherD.ID);
        }
        public void AddRoleToUser(UserRoleDTO dTO)
        {
            UserRoleCRUD roleCRUD = new UserRoleCRUD();
            roleCRUD.Create(dTO);
        }
        public List<UserPositionDTO> GetAllUsersWithRoles()
        {
            UserManager adm = new UserManager();
            return adm.GetUserVSRole();
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

        public List<UserDTO> GetAllStudents(int id)
        {
            GroupManager gm = new GroupManager();
            return gm.GetAllStudents(id);
        }
        public List<UserDTO> GetTeacherByGroupId(int Groupid)
        {
            GroupManager tc = new GroupManager();
            return tc.GetTeacherByGroupId(Groupid);
        }
        public void DeleteStudentFromGroup(int userID, int groupID)
        {
            GroupManager gm = new GroupManager();
            gm.DeleteStudentFromGroup(userID, groupID);
        }
        public void DeleteTeacherFromGroup(int userID, int groupID)
        {
            GroupManager gm = new GroupManager();
            gm.DeleteTeacherFromGroup(userID, groupID);
        }
    }
}
