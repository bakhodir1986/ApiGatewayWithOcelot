namespace IdentityManagementSystem.Models
{
    public interface IIdentityRepository
    {
        void AddRole(Roles role);
        void AddRolePermissions(RolePermissions item);
        void AddUser(User user);
        void AddUserRole(UserRoles item);

        UserModel GetUser(string login, string password);

        IEnumerable<User> GetUsers();
        IEnumerable<Roles> GetRoles();
        IEnumerable<UserRoles> GetUserRoles();
        IEnumerable<RolePermissions> GetRolePermissions();
    }
}