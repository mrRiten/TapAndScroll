using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Models
{
    public class Favorites
    {
        [Key]
        public int IdFavorites { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } 
    }
}
