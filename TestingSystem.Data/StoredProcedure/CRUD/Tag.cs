using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure.CRUD
{
    public class Tag
    {
        public int Create(TagDTO tag)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Tag_Add";
                int tagID = connection.Query<int>(sqlExpression, tag, commandType: CommandType.StoredProcedure).FirstOrDefault();
                tag.ID = tagID;
                return tagID;
            }
        }

        public List<TagDTO> ReadAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Tag_GetAll";
                List<TagDTO> tags = new List<TagDTO>();
                return connection.Query<TagDTO>(sqlExpression, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public TagDTO Read(int id)
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
