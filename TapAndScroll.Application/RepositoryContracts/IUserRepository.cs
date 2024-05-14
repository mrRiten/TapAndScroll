using TapAndScroll.Core.Models;

namespace TapAndScroll.Application.RepositoryContracts
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByIdAsync(int userId);
        public Task<User?> GetUserByEmailAsync(string email);

        public Task CreateUserAsync(User user);
        public Task UpdateUserAsync(User user);

        public Task DeleteUserAsync(int userId);
    }
}
