using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Models
{
    public class ImgProduct
    {
        [Key]
        public int IdImgProduct { get; set; }

        public int ProductId { get; set; }

        public string ImgPath { get; set; }
    }
}
