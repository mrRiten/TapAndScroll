using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Application.ServiceContracts
{
    public interface IUserService
    {
        public Task<User> GetUserAsync(int userId);
        public Task<ICollection<User>> GetUsersAsync();

        public Task DeleteUserAsync(int userId);
        public Task UpdateUserAsync(User user);
        public Task CreateUserAsync(UploadRegisterUser model);
    }
}
