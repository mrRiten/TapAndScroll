using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Models
{
    public class Product
    {
        [Key]
        public int IdProduct {  get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public string AdditionalParameters { get; set; }
    }
}
