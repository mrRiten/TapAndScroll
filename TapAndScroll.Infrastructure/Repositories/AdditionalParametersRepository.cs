using Microsoft.EntityFrameworkCore;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Core;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Repositories
{
    public class AdditionalParametersRepository(TapAndScrollDbContext context) : IAdditionalParametersRepository
    {
        private readonly TapAndScrollDbContext _context = context;

        public async Task CreateAsync(AdditionalParametersCategory[] additionalParametersList)
        {
            await _context.AdditionalParametersCategory
                .AddRangeAsync(additionalParametersList);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int categoryId)
        {
            var targetList = await GetByCategoryIdAsync(categoryId);

            _context.AdditionalParametersCategory
                .RemoveRange([.. targetList]);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<AdditionalParametersCategory>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.AdditionalParametersCategory
                .Where(apc => apc.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task UpdateAsync(AdditionalParametersCategory additionalParameters)
        {
            _context.Update(additionalParameters);

            await _context.SaveChangesAsync();
        }
    }
}
