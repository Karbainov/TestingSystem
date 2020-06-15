namespace TestingSystem.API.Models.Input
{
    public class UserRoleInputModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public UserRoleInputModel(int id, int userID, int roleID)
        {
            ID = id;
            UserID = userID;
            RoleID = roleID;
        }
        public UserRoleInputModel()
        {

        }
    }
}