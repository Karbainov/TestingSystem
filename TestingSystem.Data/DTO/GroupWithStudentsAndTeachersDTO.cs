using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Data.DTO
{
    public class GroupWithStudentsAndTeachersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<StudentDTO> students { get; set; }
        public List<TeacherDTO> teachers { get; set; }
    }
}
