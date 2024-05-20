using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Models
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }

        [Required]
        [StringLength(128)]
        public string CategoryName { get; set; }
        
        [Required]
        [StringLength(512)]
        public string CategoryDescription { get; set; }

        public string? AdditionalParameters { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
