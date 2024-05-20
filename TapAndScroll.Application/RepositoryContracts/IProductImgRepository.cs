using TapAndScroll.Core.Models;

namespace TapAndScroll.Application.RepositoryContracts
{
    public interface IProductImgRepository
    {
        public Task CreateAsync(ImgProduct imgProduct);
        public Task UpdateAsync(ImgProduct imgProduct);
        public Task DeleteAsync(int id);
        public Task<ICollection<ImgProduct>> GetImagesByIdProductAsync(int id);
    }
}
