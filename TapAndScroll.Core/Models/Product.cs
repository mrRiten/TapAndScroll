using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TapAndScroll.Core.Models
{
    public class Product
    {
        [Key]
        public int IdProduct {  get; set; }

        [Required]
        [StringLength(128)]
        public string ProductName { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }

        public int Page { get; set; }
        
        public ICollection<ImgProduct> Products { get; set; }

        public ICollection<AdditionalParameters> Parameters { get; set; }

        public ICollection<Favorites> Favorites { get; set; }

        public ICollection<OrderProduct> Order { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<Basket> Baskets { get; set; }
    }
}
