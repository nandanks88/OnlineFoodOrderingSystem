using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrderingSystem.Models
{
    public class UserRole
    {
      
        [Key]
        public int roleId { get; set; } 
        public string Role { get; set; }

        // Navigation back to RegisterVM
        public RegisterVM RegisterVM { get; set; }

        // Foreign key to RegisterVM
        // public int RegisterVMId { get; set; }

    }
}
