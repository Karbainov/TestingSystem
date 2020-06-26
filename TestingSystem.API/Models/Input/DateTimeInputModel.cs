using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Input
{
    public class DateTimeInputModel
    {
        public string PeriodStart { get; set; }
        public string PeriodEnd { get; set; }

        public DateTime StringConverToDateTime(string date)
        {
            DateTime dateTime = Convert.ToDateTime(date);
            return dateTime;
        }
    }

    
}
