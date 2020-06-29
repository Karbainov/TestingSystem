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
    public class GroupCRUD
    {
        public bool Add(GroupDTO group)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_Add @name, @startDate, @endDate ";
                return connection.Query<bool>(sqlExpression, group).FirstOrDefault();
            }
        }

        public List<GroupDTO> GetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_GetAll";
                return connection.Query<GroupDTO>(sqlExpression).ToList();
            }
        }

        public GroupDTO GetById(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_GetById";
                return connection.Query<GroupDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public bool Update(GroupDTO group)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_Update @id, @name, @startDate, @endDate";
                return connection.Query<bool>(sqlExpression, group).FirstOrDefault();
            }
        }

        public bool Delete(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_Delete @id";
                return connection.Query<bool>(sqlExpression, id).FirstOrDefault();
            }
        }
    }
}
