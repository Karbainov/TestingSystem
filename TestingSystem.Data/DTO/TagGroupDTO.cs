using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class TagGroupDTO
    {
        public int ID { get; set; }
        public string TagName { get; set; }
        public int GroupID { get; set; }
        public string TestName { get; set; }
       
        public  TagGroupDTO (int ID, string TagName,int GroupID, string TestName)
        {
            this.ID = ID;
            this.TagName = TagName;
            this.GroupID = GroupID;
            this.TestName = TestName;
        }

        public TagGroupDTO()
        {
           
        }

    }
}
