using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;
using Dapper;
using System.Data;
using System.Linq;

namespace TestingSystem.Data.StoredProcedure
{
    public class UserPositions
    {
        public List<UserPositionDTO> UserPosition() 
        {
            
            IDbConnection usPos = Connection.GetConnection();
            List<UserPositionDTO> userPositions =new List<UserPositionDTO>();
            using (usPos)
            {
                userPositions = usPos.Query<UserPositionDTO>("User_Position").ToList();
            }

                return userPositions;
        }




        //public List<User_PositionDTO> User_Position(SqlConnection connection)
        //{
        //    connection.Open();
        //    string sqlExpression = "User_Position";

        //    SqlCommand command = new SqlCommand(sqlExpression, connection);
        //    command.CommandType = System.Data.CommandType.StoredProcedure;

        //    SqlDataReader reader = command.ExecuteReader();

        //    List<User_PositionDTO> usePosAll = new List<User_PositionDTO>();

        //    if (reader.HasRows) // если есть данные
        //    {

        //        while (reader.Read()) // построчно считываем данные
        //        {
        //            User_PositionDTO usePosAll1 = new User_PositionDTO();

        //            usePosAll1.Id = (int)reader["ID"];
        //            usePosAll1.FirstName = (string)reader["FirstName"];
        //            usePosAll1.LastName = (string)reader["LastName"];
        //            usePosAll1.Position = (string)reader["Position"];
        //            usePosAll.Add(usePosAll1);
        //        }
        //    }
        //    reader.Close();

        //    return usePosAll;
        //}
    }
}

