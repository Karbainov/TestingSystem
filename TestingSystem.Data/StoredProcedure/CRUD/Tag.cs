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
        public int TagCreate(TagDTO tag)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Tag_Add";
                int tagID = connection.Query<int>(sqlExpression, tag, commandType: CommandType.StoredProcedure).FirstOrDefault();
                tag.ID = tagID;
                return tagID;
            }
        }

        public List<TagDTO> TagRead()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Tag_GetAll";
                List<TagDTO> tags = new List<TagDTO>();
                return connection.Query<TagDTO>(sqlExpression, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TagDTO> TagReadById(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Tag_GetById";
                List<TagDTO> tags = new List<TagDTO>();
                return connection.Query<TagDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void TagUpdate(TagDTO tag)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Tag_Update";
                connection.Execute(sqlExpression, tag, commandType: CommandType.StoredProcedure);
            }
        }

        public void TagDelete(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Tag_Delete";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
