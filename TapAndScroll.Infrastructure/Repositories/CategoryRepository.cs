using Microsoft.EntityFrameworkCore;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Core;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Repositories
{
    public class CategoryRepository(TapAndScrollDbContext context) : ICategoryRepository
    {
        private readonly TapAndScrollDbContext _context = context;

        public async Task<Category?> CreateAsync(Category category)
        {
            await _context.Categories
                .AddAsync(category);
            
            await _context.SaveChangesAsync();

            return await _context.Categories
                .OrderByDescending(c => c.IdCategory)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories
                .FindAsync(id);

            if (category == null) { return; }
            _context.Categories
                .Remove(category);
            
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _context.Categories
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.AdditionalParametersCategory)
                .FirstOrDefaultAsync(c => c.IdCategory == id);
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.CategoryName == name);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories
                .Update(category);

            await _context.SaveChangesAsync();
        }
    }
}
