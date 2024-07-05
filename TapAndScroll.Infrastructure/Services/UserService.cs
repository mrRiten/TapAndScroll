using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Infrastructure.Services
{
    public class UserService(IUserRepository userRepository, IConfirmHelper confirmHelper) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IConfirmHelper _confirmHelper = confirmHelper;

        public async Task CreateUserAsync(UploadRegisterUser model)
        {
            var user = new User
            {
                UserName = model.UserName,
                HashPassword = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Email = model.Email,
                RoleId = 1,
                ConfirmToken = _confirmHelper.GenerateTokenAsync()
            };

            await _userRepository.CreateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public Task<ICollection<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
