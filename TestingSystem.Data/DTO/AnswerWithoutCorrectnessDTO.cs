using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;
using Dapper;
using System.Linq;
using System.Data;

namespace TestingSystem.Data.DTO
{
   public class AnswerWithoutCorrectnessDTO
    {
        public int ID { get; set; }

        public int QiestionId { get; set; }

        public string Value { get; set; }


    }
}
