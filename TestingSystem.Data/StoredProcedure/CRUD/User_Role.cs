using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    class User_Role
    {
        public int User_Role_Create( User_RoleDTO user_Role)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_Create @RoleID,@UserID";
                return connection.Query<int>(sqlExpression, user_Role).FirstOrDefault();
            }
           
        }
        public int User_Role_Delete( User_RoleDTO user_Role)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_Delete @RoleID,@UserID";
                return connection.Query<int>(sqlExpression, user_Role).FirstOrDefault();
            }
        }
        public List<User_RoleDTO> User_Role_Read()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_Read";
                return connection.Query<User_RoleDTO>(sqlExpression).ToList();
            }
        }
        public List<User_RoleDTO> User_Role_ReadByUserID( User_RoleDTO user_Role)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_ReadByUserID @UserID";
                return connection.Query<User_RoleDTO>(sqlExpression,user_Role).ToList();
            }
        }
        public List<User_RoleDTO> User_Role_ReadByRoleID( User_RoleDTO user_Role)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_ReadByRoleID @RoleID";
                return connection.Query<User_RoleDTO>(sqlExpression, user_Role).ToList();
            }
        }
    }
}
