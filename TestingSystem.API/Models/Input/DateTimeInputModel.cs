using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Input
{
    public class DateTimeInputModel
    {
        public string DateTime1 { get; set; }
        public string DateTime2 { get; set; }

        public DateTime StringConverToDateTime(string date)
        {
            DateTime dateTime = Convert.ToDateTime(date);
            return dateTime;
        }
    }

    
}
