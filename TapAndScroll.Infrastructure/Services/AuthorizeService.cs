using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Infrastructure.Services
{
    public class AuthorizeService(IUserRepository userRepository, IConfirmHelper confirmHelper) : IAuthorizeService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IConfirmHelper _confirmHelper = confirmHelper;

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
            var user = new User
            {
                UserName = model.UserName,
                HashPassword = model.Password,
                Email = model.Email,
                RoleId = 1,
                ConfirmToken = _confirmHelper.GenerateTokenAsync(),
            };

            await _userRepository.CreateUserAsync(user);

            return user;
        }

        public async Task<bool> ValidateAsync(UploadRegisterUser model)
        {
            var user = await _userRepository.GetUserByEmailAsync(model.Email);
            if (user == null) { return true;}
            return false;
        }
    }
}
