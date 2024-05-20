using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.UploadModels
{
    public class UploadCategory
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(512)]
        public string Description { get; set; }

        public string AdditionalParameters { get; set; }
    }
}
