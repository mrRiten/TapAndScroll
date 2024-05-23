using Microsoft.AspNetCore.Http;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Services
{
    public class ImageProductService(IProductImgRepository imgRepository) : IImageProductService
    {
        private readonly IProductImgRepository _imgRepository = imgRepository;

        public async Task CreateImageProductAsync(int productId, ICollection<IFormFile> files)
        {
            var imgProducts = new List<ImgProduct>();

            foreach ( var file in files)
            {
                imgProducts.Add(new ImgProduct { ProductId = productId, ImgPath = $"{productId}/{file.FileName}" });
            }

            await _imgRepository.CreateAsync([..imgProducts]);
        }

        public async Task DeleteImageProductAsync(int idProduct)
        {
            await _imgRepository.DeleteAsync(idProduct);
        }

        public async Task<ICollection<ImgProduct>> GetImageProductAsync(int idProduct)
        {
            return await _imgRepository.GetImagesByIdProductAsync(idProduct);
        }

        public async Task UpdateImageProductAsync(ImgProduct imgProduct)
        {
            await _imgRepository.UpdateAsync(imgProduct);
        }
    }
}
