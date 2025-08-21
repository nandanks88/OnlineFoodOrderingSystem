using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineFoodOrderingSystem.Data;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;

        private readonly UserManager<IdentityRole> roleManager;
        
        private readonly AppDbContext context;
        private readonly IConfiguration configuration;

        public AuthenticationController(UserManager<ApplicationUser> _userManager, UserManager<IdentityRole> _roleManager, AppDbContext _context,IConfiguration _configuration)
        {
            userManager= _userManager;
            roleManager = _roleManager;
            context = _context;
                configuration= _configuration;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Result([FromBody] RegisterVM registerVM)
        {
            if (!ModelState.IsValid) { 
                return BadRequest("Please , provide all the required fields");
            }
            var userExists = await userManager.FindByEmailAsync(registerVM.EmailId);
            if (userExists != null) {
                return BadRequest($"User{registerVM.EmailId} already exists");
            }
            ApplicationUser newUser = new ApplicationUser()
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.EmailId,
                UserName = registerVM.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result= await userManager.CreateAsync(newUser, registerVM.Password);
            if (result.Succeeded) { 
             return Ok(result);
            }
           return BadRequest("User could not be created");
        }
        public IActionResult Index() 
        {
            return View();
        }
    }
}
