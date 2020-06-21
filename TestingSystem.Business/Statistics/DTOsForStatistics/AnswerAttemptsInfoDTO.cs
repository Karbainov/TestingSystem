using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO.DTOsForStatistics
{
   public class AnswerAttemptsInfoDTO
    {
        public int AnswersStudentId { get; set; }
        public List<int> AttemptId { get; set; }

    }
}
