﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    class RoleCRUD
    {
        public int Add(string name)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Role_Add @Name";
                return  connection.Query<int>(sqlExpression, new{name}).FirstOrDefault();
            }
        }
        public void Delete( int id)
        {
           
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Role_Delete @ID";
                connection.Query<int>(sqlExpression,new { id });
            }
        }
        public void Update( RoleDTO role)
        {
          

            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Role_Update @Name,@ID";
                connection.Query<int>(sqlExpression, role);
            }
        }
        public List<RoleDTO> GetAll()
        {  
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Role_Get ";
                return  connection.Query<RoleDTO>(sqlExpression).ToList();
            }
        }
        public List<RoleDTO> GetById( int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();
                string sqlExpression = "Role_GetById @ID ";
                List<RoleDTO> roles = new List<RoleDTO>();
                try
                {
                    roles = connection.Query<RoleDTO>(sqlExpression, new { id }).ToList();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
                return roles;
            }
        }
    }
}
