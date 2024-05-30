using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Models
{
    public class AdditionalParameters
    {
        [Key]
        public int IdAAdditionalParameters { get; set; }

        public int ProductId {  get; set; }
        public Product Product { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
