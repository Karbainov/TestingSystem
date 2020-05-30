using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class AttemptResultDTO
    {        
        public int number { get; set; }        
        public int result { get; set; }
        public DateTime date { get; set; }
        public TimeSpan duration { get; set; }
    }
}
