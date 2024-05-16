using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Infrastructure.Services
{
    public class AuthorizeService(IUserRepository userRepository, IConfirmHelper confirmHelper,
        IJwtHelper jwtHelper) : IAuthorizeService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IConfirmHelper _confirmHelper = confirmHelper;
        private readonly IJwtHelper _jwtHelper = jwtHelper;

        public async Task<string> AuthorizeAsync(UploadAuthorizeModel model)
        {
            var user = await _userRepository.GetUserByLoginAsync(model.Login);

            var result = BCrypt.Net.BCrypt.Verify(model.Password, user.HashPassword);
            if (result == false) { return string.Empty; }

            var token = _jwtHelper.GenerateJwtToken(user);
            return token;
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
