﻿using System;
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
            user.Add(userC);
        }
        
        public void UserRoleCreate(UserRoleDTO userRole)
        {
            UserRoleCRUD user = new UserRoleCRUD();
            user.Add(userRole);
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
            int result = user.Update(userU);
            return result;
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

        public int GroupUpdate(GroupDTO groupU)
        {
            GroupCRUD group = new GroupCRUD();
            int result = group.Update(groupU);
            return result;
        }
        public void GroupDelete(int id)   // скорректировала название Горина
        {
            GroupCRUD group = new GroupCRUD();
            group.Delete(id);
        }
        public void StudentAddInGroup (int userId, int groupId) 
        {
            StudentGroupDTO studentA = new StudentGroupDTO(1, userId, groupId);
            StudentGroup student = new StudentGroup();
            student.Add(studentA);
        }
        public void StudentDeleteFromGroup(StudentGroupDTO studentD)
        {
            StudentGroup student = new StudentGroup();
            student.Delete(studentD.ID);
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
        public void TeacherAdd(int userId, int groupId)
        {
            TeacherGroupDTO teacherA = new TeacherGroupDTO(1, userId, groupId);
            TeacherGroup teacher = new TeacherGroup();
            teacher.Add(teacherA);
        }
        public void TeacherDelete(TeacherGroupDTO teacherD)
        {
            TeacherGroup teacher = new TeacherGroup();
            teacher.Delete(teacherD.ID);
        }
        public void AddRoleToUser(UserRoleDTO dto)
        {
            UserRoleCRUD roleCRUD = new UserRoleCRUD();
            roleCRUD.Add(dto);
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
        public List<UserDTO> GetUsersByRoleID(int roleId)
        {
            UserManager users = new UserManager();
            return users.GetUsersByRoleID(roleId);
        }
        public void UserRoleDelete(int userId, int roleId)
        {
            UserRoleCRUD userRoleCRUD = new UserRoleCRUD();
            UserRoleDTO userRoleDTO = new UserRoleDTO(0, userId, roleId);
            userRoleCRUD.Delete(userRoleDTO);
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
        public void DeleteStudentFromGroup(int userId, int groupId)
        {
            GroupManager gm = new GroupManager();
            gm.DeleteStudentFromGroup(userId, groupId);
        }
        public void DeleteTeacherFromGroup(int userId, int groupId)
        {
            GroupManager gm = new GroupManager();
            gm.DeleteTeacherFromGroup(userId, groupId);
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
            //return manager.GetDeletedGroups();
            return manager.GetDeletedGroupsOneToMany();
        }
        public int RestoreGroup(int id)
        {
            ForDeletedManager manager = new ForDeletedManager();
            return manager.RestoreGroup(id);
        }

        public List<UserRoleDTO> GetRoleByRoleID(int roleId)
        {
            UserRoleCRUD role = new UserRoleCRUD();
            return role.GetByRoleID(roleId);
        }
    }
}
