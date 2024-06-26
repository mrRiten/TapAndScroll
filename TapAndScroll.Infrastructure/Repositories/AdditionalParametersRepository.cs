﻿using Microsoft.EntityFrameworkCore;
using TapAndScroll.Core;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Repositories
{
    public class AdditionalParametersRepository(TapAndScrollDbContext context) : IAdditionalParametersRepository
    {
        private readonly TapAndScrollDbContext _context = context;

        public async Task CreateAsync(AdditionalParameters[] additionalParameters)
        {
            await _context.AdditionalParameters
                .AddRangeAsync(additionalParameters);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AdditionalParameters[] additionalParameters)
        {
            _context.AdditionalParameters
                .UpdateRange(additionalParameters);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var targetParameters = _context.AdditionalParameters
                .Where(ap => ap.ProductId == id);

            _context.AdditionalParameters
                .RemoveRange(targetParameters);
        }

        public async Task<ICollection<AdditionalParameters>> GetAll(int categoryId)
        {
            return await _context.AdditionalParameters
                .Include(ap => ap.Product)
                .Where(ap => ap.Product.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<ICollection<AdditionalParameters>> GetByProductId(int productId)
        {
            return await _context.AdditionalParameters
                .AsNoTracking()
                .Where(ap => ap.ProductId == productId)
                .ToListAsync();
        }
    }
}
