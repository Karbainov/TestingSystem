using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class GroupDTO
    {
        public int TeacherID { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public GroupDTO()
        {

        }

        public GroupDTO(int TeacherID, int Id, string Name, DateTime StartDate, DateTime EndDate, string FirstName, string LastName, string Email, string Phone)
        {
            this.TeacherID = TeacherID;
            this.Id = Id;
            this.Name = Name;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.Email = Email;

        }

    }
}
