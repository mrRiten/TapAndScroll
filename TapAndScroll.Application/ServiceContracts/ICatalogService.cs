using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;
using TapAndScroll.Core.ViewModels;

namespace TapAndScroll.Application.ServiceContracts
{
    public interface ICatalogService
    {
        public Task<CatalogProduct> GetProducts(int categoryId, int page);
        /// <summary>
        /// Filters products based on the specified category ID and filter criteria.
        /// </summary>
        /// <param name="categoryId">The ID of the category to filter products within.</param>
        /// <param name="filter">The filter criteria to apply, including additional parameters for filtering.</param>
        /// <returns>A collection of products that match the filter criteria.</returns>
        /// <exception cref="FormatException">Thrown if the input string for range filtering is not in the correct format.</exception>
        public Task<ICollection<ProductDTO>> FilterProduct(int categoryId, FilterUpload filter);
    }
}
