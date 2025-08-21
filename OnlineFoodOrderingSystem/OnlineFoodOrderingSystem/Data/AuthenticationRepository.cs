using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Models;
using StackExchange.Redis;

namespace OnlineFoodOrderingSystem.Data
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppDbContext _context;
        public AuthenticationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<RegisterVM> SignIn(SignInDTO signInDTO)
        {
            var user = await _context.registerUser.FirstOrDefaultAsync(u => u.emailID == signInDTO.emailID );          
              
            return user;
        }


        public async Task<UserRole> GetUserRole(int role)
        {
          var userRole = await _context.userrole.FirstOrDefaultAsync(u => u.roleId == role);
            
            return userRole;
        } 

    }
}
