using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }

        [Required]
        [StringLength(32)]
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
