using System.Collections.Generic;

namespace UserManagement.API.Models  // <--- ADD THIS LINE
{
    public class Privilege
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class ApplicationRolePrivilege
    {
        public string RoleId { get; set; } = string.Empty;
        public int PrivilegeId { get; set; }

        public virtual ApplicationRole? Role { get; set; }
        public virtual Privilege? Privilege { get; set; }
    }
} // <--- ADD THIS CLOSING BRACKET AT THE END