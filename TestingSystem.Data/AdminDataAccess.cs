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
        public int UserCreate(UserDTO userC)
        {
            
            UserCRUD user = new UserCRUD();
            return user.Add(userC);
        }
        
        public int UserRoleCreate(UserRoleDTO userRole)
        {
            UserRoleCRUD user = new UserRoleCRUD();
            return user.Add(userRole);
        }

        public List<UserDTO> GetAllUsers()
        {
            UserCRUD user = new UserCRUD();
            return user.GetAll();
        }
        
        public UserDTO GetUserByID (int id)
        {
            UserCRUD user = new UserCRUD();
            return user.GetByID(id);
        }

        public int UserUpdate(UserDTO userU)
        {
            UserCRUD user = new UserCRUD();
            return user.Update(userU);
        }
        
        public int UserDelete(int id)
        {
            UserCRUD user = new UserCRUD();
            return user.Delete(id);
        }
        
        public int GroupCreate(GroupDTO groupC)
        {
            GroupCRUD group = new GroupCRUD();
            return group.Add(groupC);
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

        public int GroupUpdate(GroupDTO groupU)
        {
            GroupCRUD group = new GroupCRUD();
            return group.Update(groupU);
        }
        
        public int GroupDelete(int id)
        {
            GroupCRUD group = new GroupCRUD();
            return group.Delete(id);
        }
        
        public int StudentAddInGroup (int userId, int groupId) 
        {
            StudentGroupDTO studentA = new StudentGroupDTO(1, userId, groupId);
            StudentGroup student = new StudentGroup();
            return student.Add(studentA);
        }
        
        public int StudentDeleteFromGroup(StudentGroupDTO studentD)
        {
            StudentGroup student = new StudentGroup();
            return student.Delete(studentD.ID);
        }
        
        public int StudentDeleteByUserIdGroupId(int userId, int groupId)
        {
            StudentGroup student = new StudentGroup();
            return student.DeleteByUserIdGroupId(userId, groupId);
        }
        
        public int TeacherDeleteByUserIdGroupId(int userId, int groupId)
        {
            TeacherGroup teacher = new TeacherGroup();
            return teacher.DeleteByUserIdGroupId(userId, groupId);
        }
        
        public int TeacherAdd(int userId, int groupId)
        {
            TeacherGroupDTO teacherA = new TeacherGroupDTO(1, userId, groupId);
            TeacherGroup teacher = new TeacherGroup();
            return teacher.Add(teacherA);
        }
        
        public int TeacherDelete(TeacherGroupDTO teacherD)
        {
            TeacherGroup teacher = new TeacherGroup();
            return teacher.Delete(teacherD.ID);
        }
        
        public int AddRoleToUser(UserRoleDTO dto)
        {
            UserRoleCRUD roleCRUD = new UserRoleCRUD();
            return roleCRUD.Add(dto);
        }
        
        public List<UserPositionDTO> GetUsersWithRoles()
        {
            UserManager adm = new UserManager();
            return adm.GetUserVSRole();
        }
        
        public List<UserRoleDTO> GetRolesByUserId(int userId)
        {
            UserRoleCRUD roleCRUD = new UserRoleCRUD();
            return roleCRUD.GetByUserID(userId);
        }
        
        public List<RoleDTO> GetRoleByUserId(int userId)
        {
            UserManager role = new UserManager();
            return role.GetRoleByUserId(userId);
        }
        
        public List<UserDTO> GetUsersByRoleId(int roleId)
        {
            UserManager users = new UserManager();
            return users.GetUsersByRoleID(roleId);
        }
        
        public int UserRoleDelete(int userId, int roleId)
        {
            UserRoleCRUD userRoleCRUD = new UserRoleCRUD();
            UserRoleDTO userRoleDTO = new UserRoleDTO(0, userId, roleId);
            return userRoleCRUD.Delete(userRoleDTO);
        }

        public List<RoleDTO> GetRoles()
        {
            RoleCRUD role = new RoleCRUD();
            return role.GetAll();
        }

        public List<UserDTO> GetStudents(int id)
        {
            GroupManager gm = new GroupManager();
            return gm.GetAllStudents(id);
        }
        
        public List<UserDTO> GetTeacherByGroupId(int groupId)
        {
            GroupManager tc = new GroupManager();
            return tc.GetTeacherByGroupId(groupId);
        }
        
        public int DeleteStudentFromGroup(int userId, int groupId)
        {
            GroupManager gm = new GroupManager();
            return gm.DeleteStudentFromGroup(userId, groupId);
        }
        
        public int DeleteTeacherFromGroup(int userId, int groupId)
        {
            GroupManager gm = new GroupManager();
            return gm.DeleteTeacherFromGroup(userId, groupId);
        }
        
        public List<UserDTO> GetDeletedUsers()
        {
            ForDeletedManager manager = new ForDeletedManager();
            return manager.GetDeletedUsers();
        }
        
        public int RestoreUser(int id)
        {
            ForDeletedManager manager = new ForDeletedManager();
            return manager.RestoreUser(id);
        }
        
        public List<TestQuestionTagDTO> GetDeletedTests()
        {
            ForDeletedManager manager = new ForDeletedManager();
            return manager.GetDeletedOneToManyTests();
        }
        
        public int RestoreTest(int id)
        {
            ForDeletedManager manager = new ForDeletedManager();
            return manager.RestoreTest(id);
        }
        
        public List<QuestionDTO> GetDeletedQuestions()
        {
            ForDeletedManager manager = new ForDeletedManager();
            return manager.GetDeletedQuestions();
        }
        
        public int RestoreQuestion(int id)
        {
            ForDeletedManager manager = new ForDeletedManager();
            return manager.RestoreQuestion(id);
        }
        
        public List<GroupWithStudentsAndTeachersDTO> GetDeletedGroups()
        {
            ForDeletedManager manager = new ForDeletedManager();
            return manager.GetDeletedGroupsOneToMany();
        }
        
        public int RestoreGroup(int id)
        {
            ForDeletedManager manager = new ForDeletedManager();
            return manager.RestoreGroup(id);
        }

        public List<UserRoleDTO> GetRoleByRoleId(int roleId)
        {
            UserRoleCRUD role = new UserRoleCRUD();
            return role.GetByRoleID(roleId);
        }

        public UserPositionDTO GetUserWithRolesByUserId(int id)
        {
            UserManager adm = new UserManager();
            return adm.GetUserWithRolesByUserId(id);
        }
        
        public int AddUserWithRole(UserWithRoleDTO userRole)
        {
            UserManager adm = new UserManager();
            return adm.AddUserWithRole(userRole);
        }
    }
}
