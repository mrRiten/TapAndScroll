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
        public string Brand { get; set; }

        [Required]
        [StringLength(128)]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Price { get; set; }

        [Required]
        public bool IsGaming { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }

        public float? Rating { get; set; }

        public float DiscountPercent { get; set; }

        public int Page { get; set; }

        public string AdditionalParameters { get; set; }

        [NotMapped]
        public Dictionary<string, string> Parameters
        {
            get => string.IsNullOrEmpty(AdditionalParameters) ? [] : JsonConvert.DeserializeObject<Dictionary<string, string>>(AdditionalParameters);
            set => AdditionalParameters = JsonConvert.SerializeObject(value, Formatting.Indented);
        }
        
        public ICollection<ImgProduct> Products { get; set; }

        public ICollection<Favorites> Favorites { get; set; }

        public ICollection<OrderProduct> Order { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<Basket> Baskets { get; set; }
    }
}
