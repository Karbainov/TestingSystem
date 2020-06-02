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
    public class Group
    {
        public int GroupAdd(GroupDTO group)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_Add @name,@startDate,@endDate ";
                int groupID = connection.Query<int>(sqlExpression, group).FirstOrDefault();
                group.id = groupID;
                return groupID;
            }
        }

        public List<GroupDTO> GroupGetAll()
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_GetAll";
                return connection.Query<GroupDTO>(sqlExpression).ToList();
            }
        }

        public GroupDTO GroupGetById(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_GetById";
                return connection.Query<GroupDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void GroupUpdate(GroupDTO group)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_Update";
                connection.Execute(sqlExpression, group, commandType: CommandType.StoredProcedure);
            }
        }


        public void GroupDelete(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_Delete";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
