﻿using TapAndScroll.Core.Models;

namespace TapAndScroll.Application.RepositoryContracts
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync(int categoryId);
        public Task<Product?> GetProductByIdAsync(int productId);

        public Task<Product?> GetLastProductAsync(int categoryId);

        public Task<Product> CreateAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(int productId);
    }
}
