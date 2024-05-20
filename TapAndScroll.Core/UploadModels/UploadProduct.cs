using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TapAndScroll.Core.Models;
using Microsoft.AspNetCore.Http;

namespace TapAndScroll.Core.UploadModels
{
    public class UploadProduct
    {
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

        public float DiscountPercent { get; set; }

        public string AdditionalParameters { get; set; }

        public ICollection<IFormFile> ProductImg { get; set; }
    }
}
