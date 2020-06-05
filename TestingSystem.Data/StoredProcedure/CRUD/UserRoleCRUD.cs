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
    class UserRoleCRUD
    {
        public int Create( User_RoleDTO user_Role)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_Create @RoleID,@UserID";
                return connection.Query<int>(sqlExpression, user_Role).FirstOrDefault();
            }
           
        }
        public int Delete( User_RoleDTO user_Role)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_Delete @RoleID,@UserID";
                return connection.Query<int>(sqlExpression, user_Role).FirstOrDefault();
            }
        }
        public List<User_RoleDTO> Read()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_Read";
                return connection.Query<User_RoleDTO>(sqlExpression).ToList();
            }
        }
        public List<User_RoleDTO> ReadByUserID( User_RoleDTO user_Role)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_ReadByUserID @UserID";
                return connection.Query<User_RoleDTO>(sqlExpression,user_Role).ToList();
            }
        }
        public List<User_RoleDTO> ReadByRoleID( User_RoleDTO user_Role)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Role_ReadByRoleID @RoleID";
                return connection.Query<User_RoleDTO>(sqlExpression, user_Role).ToList();
            }
        }
    }
}
