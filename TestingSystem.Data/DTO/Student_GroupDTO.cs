using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class Student_GroupDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public Student_GroupDTO(int id, int userID, int groupID)
        {
            ID = id;
            UserID = userID;
            GroupID = groupID;
        }
        public Student_GroupDTO()
        {

        }
    }
}
