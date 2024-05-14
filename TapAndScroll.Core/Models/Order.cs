using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TapAndScroll.Core.Models
{
    public class Order
    {
        [Key]
        public int IdOrder { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal TotalPrice { get; set; }

        public bool IsReady { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
