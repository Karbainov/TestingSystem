using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class StudentOutputModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TestAttemptOutputModel> DTO { get; set; }
        public StudentOutputModel(int id, string firstname, string lastname, List<TestAttemptOutputModel> dto)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            DTO = dto;
        }
        public StudentOutputModel()
        { }
    }
}
