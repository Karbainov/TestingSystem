using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;

namespace TestingSystem.Data.StoredProcedure
{
    public class TeacherByGroupId
    {
        public TeacherByGroupId()
        {
        }

        public List<UserDTO> GetTeacherByGroupId(int Groupid)
        {
            var connection = Connection.GetConnection();
            connection.Open();
            string sqlExpression = "GetTeacherByGroupID";
            List<UserDTO> teachers = connection.Query<UserDTO>(sqlExpression, new { Groupid }, commandType: CommandType.StoredProcedure).ToList();
            return teachers;
        }
    }
}
