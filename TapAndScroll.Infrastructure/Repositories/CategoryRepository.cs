using Microsoft.EntityFrameworkCore;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Core;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Repositories
{
    public class CategoryRepository(TapAndScrollDbContext context) : ICategoryRepository
    {
        private readonly TapAndScrollDbContext _context = context;

        public async Task CreateAsync(Category category)
        {
            await _context.Categories
                .AddAsync(category);
            
            await _context.SaveChangesAsync();
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
                .FindAsync(id);
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
