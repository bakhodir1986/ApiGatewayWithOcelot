using System.ComponentModel.DataAnnotations;

namespace IdentityManagementSystem.Models
{
    public class RolePermissions
    {
        [Key]
        public Guid Id { get; set; }
        public string? RoleName { get; set; }
        public string? Action { get; set; }
    }
}
