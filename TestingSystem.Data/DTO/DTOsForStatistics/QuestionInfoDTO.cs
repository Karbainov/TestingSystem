using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO.DTOsForStatistics
{
    public class QuestionInfoDTO
    {
        public int TestID { get; set; }
        public string Value { get; set; }
        public int TypeID { get; set; }
        public byte AnswersCount { get; set; }
        public byte Weight { get; set; }
        public List<int> AnswersId { get; set; }
    }
}
