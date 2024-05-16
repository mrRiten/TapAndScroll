using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;
using BCrypt.Net;

namespace TapAndScroll.Infrastructure.Services
{
    public class AuthorizeService(IUserRepository userRepository, IConfirmHelper confirmHelper) : IAuthorizeService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IConfirmHelper _confirmHelper = confirmHelper;

        public Task AuthorizeAsync(string userLogin, string password)
        {
            
        }

        public async Task ConfirmAsync(int userId, string token)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            
            if (user == null) { return; }

            if (user.ConfirmToken == token)
            {
                user.IsConfirm = true;
                await _userRepository.UpdateUserAsync(user);
            }
        }

        public async Task<User> RegisterAsync(UploadRegisterUser model)
        {
            
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var user = new User
            {
                UserName = model.UserName,
                HashPassword = hashPassword,
                Email = model.Email,
                RoleId = 1,
                ConfirmToken = _confirmHelper.GenerateTokenAsync(),
            };

            await _userRepository.CreateUserAsync(user);

            return user;
        }
    }
}
