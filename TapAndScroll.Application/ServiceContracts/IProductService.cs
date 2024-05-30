﻿using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels; 

namespace TapAndScroll.Application.ServiceContracts
{
    public interface IProductService
    {
        public Task<ICollection<Product>> GetProductsAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task<Product> GetProductByNameAsync(string name);
        public Task<ICollection<Product>> GetProductsByParameters(int categoryId, FilterUpload filter);

        public Task<Product> CreateProductAsync(UploadProduct model);
        public Task UpdateProductAsync(Product model);
        public Task DeleteProductAsync(int id);
    }
}
