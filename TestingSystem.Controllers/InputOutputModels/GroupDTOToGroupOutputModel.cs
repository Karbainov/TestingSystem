using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using TestingSystem.Data.DTO;
using TestingSystem.Data.StoredProcedure;
using TestingSystem.Data.StoredProcedure.CRUD;

namespace TestingSystem.Controllers.InputOutputModels
{
    public static class GroupDTOToGroupOutputModel

    {
        public static GroupOutputModel Mapp(int groupId, List<GroupDTO> group)
        {
            GroupOutputModel grom = new GroupOutputModel();
            grom.groupID = groupId;
            grom.group = group;
            return grom;
        }
    }
}
