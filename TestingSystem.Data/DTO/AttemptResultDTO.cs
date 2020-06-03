using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class AttemptResultDTO
    {        
        public int Number { get; set; }        
        public int Result { get; set; }
        public DateTime Datetime { get; set; }
        public TimeSpan Duration { get; set; }

        public AttemptResultDTO()
        {
        }
    }
}
