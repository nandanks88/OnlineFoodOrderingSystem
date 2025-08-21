using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.Data
{
    public interface IAuthenticationRepository
    {
        public Task<RegisterVM> SignIn(SignInDTO signInDTO);
        public Task<UserRole> GetUserRole(int role);       
    }
}