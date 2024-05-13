using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
    }
}
