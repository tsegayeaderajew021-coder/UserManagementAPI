using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Models;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // ይህ ተጠቃሚ ለመመዝገብ (Register) የሚረዳ ነው
        [HttpPost("register")]
        public async Task<IActionResult> Register(string email, string password)
        {
            var user = new ApplicationUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return Ok("ተጠቃሚው በትክክል ተመዝግቧል! (User Created Successfully!)");
            }

            return BadRequest(result.Errors);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                // እዚህ ጋር Token መፈጠር አለበት (ለአሁኑ ግን ገብተሃል ለማለት Ok እንበለው)
                return Ok(new { Message = "Login Successful!", User = user.Email });
            }
            return Unauthorized("ኢሜል ወይም ፓስወርድ ተሳስተሃል!");
        }
    }
}