using Microsoft.EntityFrameworkCore;

namespace IdentityManagementSystem.Models
{
    public class IdentityDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }

        public IdentityDbContext()
        {

        }

        public DbSet<User>? Users { get; set; }
        public DbSet<UserRoles>? UserRole { get; set; }
        public DbSet<Roles>? Role { get; set; }
        public DbSet<RolePermissions>? RolePermission { get; set; }
    }
}
