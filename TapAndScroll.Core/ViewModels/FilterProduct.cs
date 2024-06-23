using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Core.ViewModels
{
    public class FilterProduct
    {
        public Category Category { get; set; }
        public FilterUpload? FilterUpload { get; set; }
        public ICollection<ProductDTO>? Products { get; set; }
    }
}
