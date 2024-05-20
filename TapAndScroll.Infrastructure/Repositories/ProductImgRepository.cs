using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Core;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Repositories
{
    public class ProductImgRepository(TapAndScrollDbContext context) : IProductImgRepository
    {
        private readonly TapAndScrollDbContext _context = context;

        public async Task CreateAsync(ImgProduct imgProduct)
        {
            await _context.ImgProducts
                .AddAsync(imgProduct);
            
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ImgProduct>> GetImagesByIdProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ImgProduct imgProduct)
        {
            throw new NotImplementedException();
        }
    }
}
