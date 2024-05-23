﻿using TapAndScroll.Core.Models;

namespace TapAndScroll.Application.RepositoryContracts
{
    public interface IProductRepository
    {
        public Task<ICollection<Product>> GetAllAsync();
        public Task<Product?> GetProductByIdAsync(int productId);
        public Task<Product?> GetProductByNameAsync(string name);
        public Task<ICollection<Product>> GetProductsByCategoryAsync(int categoryId, int page);
        public Task<ICollection<Product>> GetProductsByPropertyAsync(Product product);

        public Task<int> GetCountProductOnPageAsync();
        public Task<Product?> GetLastProductAsync();

        public Task CreateAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(int productId);
    }
}
