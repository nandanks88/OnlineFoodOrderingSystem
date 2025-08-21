using StackExchange.Redis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodOrderingSystem.Models
{
    public class RegisterVM
    {

        // FName, LNaME, eMAILId, MobileNumnber ,Passwrod //// Encryption,addr
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int ID { get; set; }


        public string emailID { get; set; }
        public string Fname { get; set; }
        public string LName { get; set; }
        public int mobileNumber { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; }
       
       // [ForeignKey("UserRole")]
        public int roleID { get; set; }
        // 1:N relationship → One RegisterVM can have many UserRoles
       // public ICollection<UserRole> UserRoles { get; set; }
       public UserRole UserRoles { get; set; }

    }

    //public class Role
    //{
    //    [Key]
    //  public int RoleId { get; set; }
    // public   string RoleName { get; set; }
    //    // Other properties related to the role can be added here
    //}
}
