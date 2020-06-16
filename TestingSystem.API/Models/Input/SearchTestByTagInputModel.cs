using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Input
{
    public class SearchTestByTagInputModel
    {
        public bool SwitchValue { get; set; }
        public string[] Tag { get; set; }

        public SearchTestByTagInputModel(bool switchValue) 
        {
            this.SwitchValue = switchValue;
            this.Tag = new string[] { };
        }
    }
}
