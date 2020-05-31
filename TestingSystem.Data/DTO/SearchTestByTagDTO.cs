using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class SearchTestByTagDTO
    {
        public string tag1 { get; set; }
        public string tag2 { get; set; }
        public string tag3 { get; set; }

        public SearchTestByTagDTO() { }

        public SearchTestByTagDTO(string tag1, string tag2, string tag3)
        {
            this.tag1 = tag1;
            this.tag2 = tag2;
            this.tag3 = tag3;
        }

    }
}
