using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    class GroupDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public GroupDTO(int _id,string _name, DateTime _startDate,DateTime _endDate)
        {
            ID = _id;
            Name = _name;
            StartDate = _startDate;
            EndDate = _endDate;
        }
        public GroupDTO()
        {

        }
    }
}
