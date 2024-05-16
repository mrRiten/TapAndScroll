using System.ComponentModel.DataAnnotations;
using TapAndScroll.Core.Attributes;

namespace TapAndScroll.Core.UploadModels
{
    public class UploadRegisterUser
    {
        [Required]
        [StringLength(64)]
        [UniqueUserName]
        public string UserName { get; set; }

        [Required]
        [StringLength(16)]
        public string Password { get; set; }

        [Required]
        [StringLength(64)]
        [UniqueEmail]
        public string Email { get; set; }
    }
}
