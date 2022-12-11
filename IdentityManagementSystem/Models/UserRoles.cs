using System.ComponentModel.DataAnnotations;

namespace IdentityManagementSystem.Models
{
    public class UserRoles
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
