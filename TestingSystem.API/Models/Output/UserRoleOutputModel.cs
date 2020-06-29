namespace TestingSystem.API.Models.Output
{
    public class UserRoleOutputModel
    {
        public int RoleID { get; set; }
        public UserRoleOutputModel(int roleID)
        {
            RoleID = roleID;
        }
        public UserRoleOutputModel()
        {

        }
    }
}