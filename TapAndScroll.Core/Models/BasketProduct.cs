using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Models
{
    public class BasketProduct
    {
        [Key]
        public int IdBasketProduct { get; set; }
    
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
