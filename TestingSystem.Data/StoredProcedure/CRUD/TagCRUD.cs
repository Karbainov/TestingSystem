using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    public class TagCRUD
    {
        public int Add(TagDTO tag)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Tag_Add @name";
                return connection.Query<int>(sqlExpression, tag).FirstOrDefault();
            }
        }

        public List<TagDTO> GetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Tag_GetAll";
                return connection.Query<TagDTO>(sqlExpression).ToList();
            }
        }

        public TagDTO GetById(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Tag_GetById";
                return connection.Query<TagDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void Update(TagDTO tag)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Tag_Update";
                connection.Execute(sqlExpression, tag, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Tag_Delete";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
