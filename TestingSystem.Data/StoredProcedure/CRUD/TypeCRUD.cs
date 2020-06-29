using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    public class TypeCRUD
    {
        public int Add(TypeDTO type)
        {
            using (System.Data.IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Type_Add @name";
                return connection.Query<int>(sqlExpression, type).FirstOrDefault();
            }
        }

        public List<TypeDTO> GetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Type_GetAll";
                return connection.Query<TypeDTO>(sqlExpression).ToList();
            }
        }

        public TypeDTO GetById(int typeId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Type_GetById";
                return connection.Query<TypeDTO>(sqlExpression, new { typeId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void Update(TypeDTO type)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Type_Update";
                connection.Execute(sqlExpression, type, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int typeId)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Type_Delete";
                connection.Execute(sqlExpression, new { typeId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
