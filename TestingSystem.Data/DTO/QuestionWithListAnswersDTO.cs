using System.Linq;
﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TestingSystem.Data.DTO;
using Dapper;
using System.Linq;
using System.Data;

namespace TestingSystem.Data.DTO
{
   public class QuestionWithListAnswersDTO
   {

        public int Id { get; set; }
       
        public string Value { get; set; }
        public int TypeID { get; set; }
       // public byte AnswersCount { get; set; }
        public byte Weight { get; set; }

        public List <AnswerWithoutCorrectnessDTO> Answers { get; set; }

        public QuestionWithListAnswersDTO(int Id, string Value, int TypeID, byte Weight, List<AnswerWithoutCorrectnessDTO> Answers)
        {
           
        }

        public QuestionWithListAnswersDTO()
        {
            
        }




    }
}
