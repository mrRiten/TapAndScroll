using Microsoft.AspNetCore.Http;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Application.ServiceContracts
{
    public interface IImageProductService
    {
        public Task CreateImageProductAsync(int idProduct, ICollection<IFormFile> files);
        public Task UpdateImageProductAsync(ImgProduct product);
        public Task DeleteImageProductAsync(int idProduct);
        public Task<ICollection<ImgProduct>> GetImageProductAsync(int idProduct);
    }
}
