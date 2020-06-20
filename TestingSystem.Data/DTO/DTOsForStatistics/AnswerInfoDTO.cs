using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO.DTOsForStatistics
{
    public class AnswerInfoDTO
    {
        public int QuestionID { get; set; }
        public string Value { get; set; }
        public bool Correct { get; set; }
    }
}
