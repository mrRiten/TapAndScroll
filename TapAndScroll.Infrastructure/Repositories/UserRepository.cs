using Microsoft.EntityFrameworkCore;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core;

namespace TapAndScroll.Infrastructure.Repositories
{
    public class UserRepository(TapAndScrollDbContext context) : IUserRepository
    {
        private readonly TapAndScrollDbContext _context = context;

        public async Task CreateUserAsync(User user)
        {
            await _context.Users
                .AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users
                .Update(user);

            await _context.SaveChangesAsync();
        }
    }
}
