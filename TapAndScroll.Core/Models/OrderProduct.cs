using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Models
{
    public class OrderProduct
    {
        [Key]
        public int IdOrderProduct { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
