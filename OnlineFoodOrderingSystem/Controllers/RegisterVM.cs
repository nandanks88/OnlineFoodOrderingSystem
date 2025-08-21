using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class RegisterVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    
    }
}