using Microsoft.EntityFrameworkCore;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Core;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.ViewModels;
using SlugGenerator;

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

        public async Task<List<ProductDTO>> GetAllAsync(int categoryId)
        {
            return await _context.Products
                .Include(p => p.Parameters)
                .Include(p => p.ImgsProduct)
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new ProductDTO
                {
                    Price = p.Parameters.FirstOrDefault(param => param.Key == "UploadProduct.Price").Value,
                    Product = p
                })
                .ToListAsync();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            product.Slug = product.ProductName.GenerateSlug();

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

        public async Task<Product?> GetProductBySlug(string slug)
        {
            return await _context.Products
                .Include(p => p.Parameters)
                .Include(p => p.ImgsProduct)
                .Include(p => p.Feedbacks)
                .FirstOrDefaultAsync(p => p.Slug == slug);
        }
    }
}
