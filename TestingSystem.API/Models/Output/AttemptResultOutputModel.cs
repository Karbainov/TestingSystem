using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
        public class AttemptResultOutputModel
        {
            public DateTime Datetime { get; set; }
            public TimeSpan Duration { get; set; }
            public int Number { get; set; }
            public int Result { get; set; }
            public string Status { get; set; }
        }
}
