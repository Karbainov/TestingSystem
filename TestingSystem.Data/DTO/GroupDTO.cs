using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class GroupDTO
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        

        public GroupDTO()
        {

        }
        
        public GroupDTO(int id, string name, DateTime startDate, DateTime endDate)
        {
            this.Id = Id;
            this.Name = Name;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public GroupDTO(int TeacherID, int Id, string Name, DateTime StartDate, DateTime EndDate, string FirstName, string LastName, string Email, string Phone)
        {
            this.Id = Id;
            this.Name = Name;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

    }
}
