using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.StoredProcedure.CRUD;

namespace TestingSystem.API
{
    public class GroupOutputModel
    {
        public int groupID;
        public List<GroupDTO> group;
    }
}
