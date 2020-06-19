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
        public int Add(GroupDTO group)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_Add @name,@startDate,@endDate ";
                int groupId = connection.Query<int>(sqlExpression, group).FirstOrDefault();
                group.Id = groupId;
                return groupId;
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

        public void Update(GroupDTO group)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_Update";
                connection.Execute(sqlExpression, group, commandType: CommandType.StoredProcedure);
            }
        }


        public void Delete(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_Delete";
                connection.Execute(sqlExpression, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
