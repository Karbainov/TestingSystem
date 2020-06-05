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
    class RoleCRUD
    {
        public int Create( RoleDTO role)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Role_Create @Name";
                role.ID = connection.Query<int>(sqlExpression, role.Name).FirstOrDefault();
                return role.ID;
            }
        }
        public void Delete( RoleDTO role)
        {
           
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Role_Delete @ID";
                connection.Query<int>(sqlExpression, role.ID);
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
        public List<RoleDTO> Read()
        {
            
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Role_Read ";
                return  connection.Query<RoleDTO>(sqlExpression).ToList();
                
            }
            
        }
        public List<RoleDTO> ReadById( RoleDTO role)
        {
            

            
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Role_ReadDyId @ID ";
                return connection.Query<RoleDTO>(sqlExpression,role).ToList();

            }
        }
    }
}
