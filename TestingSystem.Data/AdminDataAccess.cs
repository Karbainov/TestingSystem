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
        
        public void UserRoleCreate(UserRoleDTO userRole)
        {
            UserRoleCRUD user = new UserRoleCRUD();
            user.Create(userRole);
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
        public void StudentDeleteByUserIdGroupId(int userId, int groupId)
        {
            StudentGroup student = new StudentGroup();
            student.DeleteByUserIdGroupId(userId, groupId);
        }
        public void TeacherDeleteByUserIdGroupId(int userId, int groupId)
        {
            TeacherGroup teacher = new TeacherGroup();
            teacher.DeleteByUserIdGroupId(userId, groupId);
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
        public List<UserDTO> GetUsersByRoleID(int roleID)
        {
            UserRoleCRUD roleCRUD = new UserRoleCRUD();
            return roleCRUD.GetUsersByRoleID(roleID);
        }
        public void UserRoleDelete(int userId, int roleId)
        {
            UserRoleCRUD userRoleCRUD = new UserRoleCRUD();
            UserRoleDTO userRoleDTO = new UserRoleDTO(0, userId, roleId);
            userRoleCRUD.Delete(userRoleDTO);
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
        
        public List<RoleDTO> GetRoleByUserId(int userId)
        {
            UserManager role = new UserManager();
            return role.GetRoleByUserId(userId);
        }
        
    }
}
