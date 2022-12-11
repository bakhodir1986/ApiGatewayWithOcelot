using System.ComponentModel.DataAnnotations;

namespace IdentityManagementSystem.Models
{
    public class Roles
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
