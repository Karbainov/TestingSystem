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
    public class UserCRUD
    {
        public bool Add( UserDTO user)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Add @FirstName, @LastName, @BirthDate, @Login, @Password, @Email, @Phone";
                return connection.Query<bool>(sqlExpression, user).FirstOrDefault();
            }
            
        }
        public bool Update(UserDTO user)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Update  @id, @FirstName, @LastName, @BirthDate, @Login, @Password, @Email, @Phone";
                return connection.Query<bool>(sqlExpression, user).FirstOrDefault();
            }
           
        }
        public bool Delete(int id)
        {
            using (IDbConnection connection=Connection.GetConnection())
            {
                string sqlExpression = "User_Delete @id";
                return connection.Query<bool>(sqlExpression, new { id }).FirstOrDefault();
            }
        }
        public List<UserDTO> GetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_GetAll";
                return connection.Query<UserDTO>(sqlExpression).ToList();
            }
        }
        public UserDTO GetByID(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_GetByID @id";
                return connection.Query<UserDTO>(sqlExpression, new { id }).FirstOrDefault();
            }
        }
    }
}
