namespace IdentityManagementSystem.Models
{
    public class UserModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UserModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Permissions = new List<string?>();
        }
        public string UserName { get; set; }
        public string RoleName { get; set; }

        public List<string?> Permissions { get; set; }
    }
}
