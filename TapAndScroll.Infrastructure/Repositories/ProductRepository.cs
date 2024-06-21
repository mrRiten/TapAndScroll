using Microsoft.EntityFrameworkCore;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Core;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Repositories
{
    public class ProductRepository(TapAndScrollDbContext context) : IProductRepository
    {
        private readonly TapAndScrollDbContext _context = context;

        public async Task<ICollection<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _context.Products
                .FindAsync(productId);
        }

        public async Task<ICollection<Product>> GetProductsByPropertyAsync(Product product)
        {
            var products = await _context.Products
                .ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetAllAsync(int categoryId)
        {
            return await _context.Products
                .Include(p => p.Parameters)
                .Include(p => p.ImgsProduct)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products
                .AddAsync(product);

            await _context.SaveChangesAsync();

            return await _context.Products
                .OrderByDescending(p => p.IdProduct)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products
               .Update(product);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productId)
        {
            var targetProduct = await _context.Products
                .FindAsync(productId);

            if (targetProduct == null) { return; }

            _context.Products
                .Remove(targetProduct);

            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetLastProductAsync(int categoryId)
        {
            return await _context.Products
                .OrderByDescending(p => p.IdProduct)
                .FirstOrDefaultAsync(p => p.CategoryId == categoryId);
        }

    }
}
