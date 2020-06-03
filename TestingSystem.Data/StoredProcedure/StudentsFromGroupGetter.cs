using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using TestingSystem.Data.DTO;
using Dapper;


namespace TestingSystem.Data.StoredProcedure
{
    public class StudentsFromGroupGetter
    {
        public List<UserDTO> GetStudentsFromGroup(int id)
        {
            using (IDbConnection connection = Connection.GetConnection())
            {
                string sqlExpression = "Group_GetAllStudents";
                return connection.Query<UserDTO>(sqlExpression, new { id }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
