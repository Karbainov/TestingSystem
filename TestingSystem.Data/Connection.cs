﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TestingSystem.Data
{
    static class Connection
    {
        public static IDbConnection GetConnection()
        {
            string connectionString = @"Data Source=80.78.240.16;Initial Catalog=DevEduTestSystem_Test;User Id = tSystem;Password = qwe!23";//_Test
            IDbConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        
    }
}
