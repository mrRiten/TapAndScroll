using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.UploadModels
{
    public class UploadAuthorizeModel
    {
        [Required]
        [StringLength(64)]
        public string Login { get; set; }
        [Required]
        [StringLength(16)]
        public string Password { get; set; }
    }
}
