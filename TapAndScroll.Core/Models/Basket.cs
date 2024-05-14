using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TapAndScroll.Core.Models
{
    public class Basket
    {
        [Key]
        public int IdBasket { get; set; }
    
        public int UserId { get; set; }
        public User User { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal TotalPrice { get; set; }

        public ICollection<BasketProduct> Products { get; set; }
    }
}
