using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Models
{
    public class AdditionalParameters
    {
        [Key]
        public int IdAAdditionalParameters { get; set; }

        [Required]
        public int ProductId {  get; set; }
        public Product Product { get; set; }

        [Required]
        [StringLength(128)]
        public string Key { get; set; }

        [Required]
        [StringLength(128)]
        public string Value { get; set; }
    }
}
