using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // ይህ የግድ ያስፈልጋል
using Microsoft.EntityFrameworkCore; // ይህ ለ DbSet እና DbContextOptions
using UserManagement.API.Models; // የፈጠርካቸውን ሞዴሎች ለማግኘት

namespace UserManagement.API.Data
{
    // ስህተቱን ለማረም IdentityDbContext አጻጻፉን እንዲህ አስተካክለው
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<ApplicationRolePrivilege> RolePrivileges { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationRolePrivilege>()
                .HasKey(rp => new { rp.RoleId, rp.PrivilegeId });
        }
    }
}