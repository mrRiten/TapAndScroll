using Microsoft.EntityFrameworkCore;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Core;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Repositories
{
    public class ProductImageRepository(TapAndScrollDbContext context) : IProductImgRepository
    {
        private readonly TapAndScrollDbContext _context = context;

        public async Task CreateAsync(ImgProduct[] imgProduct)
        {
            await _context.ImgProducts
                .AddRangeAsync(imgProduct);

            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var targetImage = await _context.ImgProducts.FindAsync(id);

            if (targetImage == null) { return; }

            _context.ImgProducts
                .Remove(targetImage);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ImgProduct>> GetImagesByIdProductAsync(int id)
        {
            return await _context.ImgProducts
                .Where(ip => ip.ProductId == id)
                .ToListAsync();
        }

        public async Task UpdateAsync(ImgProduct imgProduct)
        {
            _context.ImgProducts
                .Update(imgProduct);

            await _context.SaveChangesAsync();
        }
    }
}
