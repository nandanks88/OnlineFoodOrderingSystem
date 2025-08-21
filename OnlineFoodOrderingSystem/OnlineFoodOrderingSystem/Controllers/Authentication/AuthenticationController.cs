using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineFoodOrderingSystem.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IConfiguration _config;
       


        public AuthenticationController( IAuthenticationRepository authenticationRepository, IConfiguration config)
        {
            _authenticationRepository = authenticationRepository;
            _config = config;   
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInDTO request)
        {
            //var user = await _appDbContext.registerUser.FirstOrDefaultAsync(u => u.emailID == request.emailID);
            //if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            //    return Unauthorized("Invalid username or password.");

            var user= await _authenticationRepository.SignIn(request);

            if(user == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            else { 

                var token = GenerateJwtToken(user);
            return Ok(new { token });
            }
        }


        private async Task<string> GenerateJwtToken(RegisterVM user)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var userRole = await _authenticationRepository.GetUserRole(user.roleID);
            var rolename = userRole?.Role ?? string.Empty; // safe null handling          

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.emailID.ToString()),
            new Claim("role", rolename)


        };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

