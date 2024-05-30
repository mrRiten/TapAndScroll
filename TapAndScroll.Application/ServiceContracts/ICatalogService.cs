using TapAndScroll.Core.UploadModels;
using TapAndScroll.Core.ViewModels;

namespace TapAndScroll.Application.ServiceContracts
{
    public interface ICatalogService
    {
        public Task<CatalogProduct> GetProducts(int categoryId, int page);
        public Task<CatalogProduct> FilterProduct(FilterUpload filter);
    }
}
