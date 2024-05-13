using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace TapAndScroll.Core.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(32)]
        public string HashPassword { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }


    }
}
