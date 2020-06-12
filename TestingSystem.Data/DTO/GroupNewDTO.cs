using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class GroupNewDTO
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        

        public GroupNewDTO()
        {

        }

        public GroupNewDTO( int Id, string Name, DateTime StartDate, DateTime EndDate)
        {
            this.Id = Id;
            this.Name = Name;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
           
        }

    }
}
