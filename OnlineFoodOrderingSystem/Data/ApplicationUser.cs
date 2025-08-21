using Microsoft.AspNetCore.Identity;

namespace OnlineFoodOrderingSystem.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Custom { get; set; }
    }
}