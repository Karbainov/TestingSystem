using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class FeedbackOutputModel
    {
        public int ID { get; set; }        
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public Boolean Processed { get; set; }
    }
}
