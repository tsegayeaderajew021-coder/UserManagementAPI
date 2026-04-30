using Microsoft.AspNetCore.Identity;

namespace UserManagement.API.Models

{
    // እዚህም ": IdentityRole" የሚለው መኖሩን አረጋግጥ
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<ApplicationRolePrivilege> RolePrivileges { get; set; } = new List<ApplicationRolePrivilege>();
    }
}