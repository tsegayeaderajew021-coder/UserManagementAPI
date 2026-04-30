using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Models;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // 1. አዲስ Role ለመፍጠር (ለምሳሌ Admin, User)
        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new ApplicationRole { Name = roleName });
                return Ok($"Role {roleName} Created!");
            }
            return BadRequest("Role already exists!");
        }

        // 2. ለተጠቃሚ Role ለመስጠት (ለምሳሌ ለ admin@test.com የ Admin Role መስጠት)
        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return NotFound("User not found!");

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded) return Ok($"User {email} is now {roleName}");

            return BadRequest(result.Errors);
        }
    }
}