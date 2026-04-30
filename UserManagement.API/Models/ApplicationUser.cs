using Microsoft.AspNetCore.Identity; // ይህ መኖሩን አረጋግጥ

namespace UserManagement.API.Models
{
    // ስህተቱ እዚህ ጋር ነው፤ ": IdentityUser" የሚለው መኖሩን አረጋግጥ
    public class ApplicationUser : IdentityUser
    {
        // ባዶ ቢሆንም ችግር የለውም
    }
}