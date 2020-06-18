using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.StoredProcedure.CRUD;
using TestingSystem.API.Models.Output;
using TestingSystem.API.Models.Input;

namespace TestingSystem.API
{
    public class GroupOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List <UserOutputModel> Students { get; set; }
        public  List<UserOutputModel> Teachers { get; set; }
    }
}
