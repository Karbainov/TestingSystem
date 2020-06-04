using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure.CRUD;
using TestingSystem.Data.StoredProcedure;


namespace TestingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            TeacherByGroupId teacher = new TeacherByGroupId();
            List<UserDTO> teachers =teacher.GetTeacherByGroupId(1);
            foreach (UserDTO t in teachers)
            {
                Console.WriteLine($"{t.FirstName}");
            }
        }
    }
}
