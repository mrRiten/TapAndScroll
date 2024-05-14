using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Models
{
    public class Feedback
    {
        [Key]
        public int IdFeedback { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Text { get; set; }

        [Required]
        [MaxLength(512)]
        public string? GoodMoment { get; set; }

        [Required]
        [MaxLength(512)]
        public string? BadMoment { get; set; }

        public int Rating { get; set; }
    }
}
