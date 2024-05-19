using Microsoft.EntityFrameworkCore;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Core;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Repositories
{
    public class ProductRepository(TapAndScrollDbContext context) : IProductRepository
    {
        private readonly TapAndScrollDbContext _context = context;

        public async Task<ICollection<Product>> GetProductsByCategoryAsync(int categoryId, int page)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId && p.Page == page)
                .ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _context.Products
                .FindAsync(productId);
        }

        public async Task<Product?> GetProductByNameAsync(string name)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.ProductName == name);
        }

        public async Task<ICollection<Product>> GetProductsByProperty(Product product)
        {
            var products = await _context.Products
                .FirstOrDefaultAsync(p => p.Brand == product.Brand );
        }
    }
}
