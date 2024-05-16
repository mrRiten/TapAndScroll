using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TapAndScroll.Core.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        [StringLength(64)]
        public string UserName { get; set; }

        [Required]
        [StringLength(64)]
        public string Email { get; set; }

        [Required]
        public string HashPassword { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal Money { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal Bonus { get; set; }

        [DefaultValue(false)]
        public bool IsConfirm { get; set; }

        [StringLength(32)]
        public string ConfirmToken { get; set; }

        [DefaultValue(1)]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Favorites> Favorites { get; set; }

        public ICollection<Basket> Baskets { get; set; }
        public ICollection<BasketProduct> BasketProducts { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
