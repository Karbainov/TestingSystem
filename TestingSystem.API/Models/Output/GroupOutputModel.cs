using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSystem.API.Models.Output
{
    public class GroupOutputModel
    { 
      
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public List<StudentModel> students { get; set; }
        public List<TeacherModel> teachers { get; set; }
    }
}
