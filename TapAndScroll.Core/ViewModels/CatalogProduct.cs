using TapAndScroll.Core.Models;

namespace TapAndScroll.Core.ViewModels
{
    public class CatalogProduct
    {
        public Category Category { get; set; }

        public ICollection<Product> Products { get; set;}

    }
}
