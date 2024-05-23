using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Models
{
    public class AdditionalParametersCategory
    {
        [Key]
        public int IdAdditionalParameters { get; set; }
        
        public int CategoryId { get; set; }

        public string NameParameters { get; set; }

        public string SlugParameters { get; set; }
    
        public Category Category { get; set; }
    }
}
