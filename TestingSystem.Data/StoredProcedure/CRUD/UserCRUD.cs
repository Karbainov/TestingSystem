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
    class UserCRUD
    {
        public int Create( UserDTO user)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Create @FirstName,@LastName,@BirthDate,@Login,@Password,@Email,@Phone";
                return connection.Query<int>(sqlExpression, user).FirstOrDefault();
            }
            
        }
        public int Update( UserDTO user)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_Update  @id,@FirstName,@LastName,@BirthDate,@Login,@Password,@Email,@Phone";
                return connection.Query<int>(sqlExpression, user).FirstOrDefault();
            }
           
        }
        public int Delete(int id)
        {
            using (IDbConnection connection=Connection.GetConnection())
            {
                string sqlExpression = "User_Delete @id";
                return connection.Query<int>(sqlExpression, new { id }).FirstOrDefault();
            }
        }
        public List<UserDTO> GetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_ReadAll";
                return connection.Query<UserDTO>(sqlExpression).ToList();
            }
        }
        public UserDTO GetByID(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "User_ReadByID @id";
                return connection.Query<UserDTO>(sqlExpression, new { id }).FirstOrDefault();
            }
        }
    }
}
