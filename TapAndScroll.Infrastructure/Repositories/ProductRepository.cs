﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<Product>> GetProductsByPropertyAsync(Product product)
        {
            var products = await _context.Products
                .Where(p => p.Brand == product.Brand )
                .ToListAsync();

            return products;
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _context.Products
                .ToListAsync();
        }

        public async Task CreateAsync(Product product)
        {
            await _context.Products
                .AddAsync(product);

            await _context.SaveChangesAsync();
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

        public async Task<int> GetCountProductOnPageAsync()
        {
            var product = await GetLastProductAsync();

            if (product == null) { return 0; }

            var products = await _context.Products
                .Where(p => p.Page == product.Page)
                .ToListAsync();

            return products.Count;
        }

        public async Task<Product?> GetLastProductAsync()
        {
            return await _context.Products
                .OrderByDescending(p => p.IdProduct)
                .FirstOrDefaultAsync();
        }
    }
}
