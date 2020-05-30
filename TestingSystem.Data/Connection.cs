using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TestingSystem.Data
{
    static class Connection
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=80.78.240.16;Initial Catalog=DevEduTestSystem;User Id = tSystem;Password = qwe!23";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
