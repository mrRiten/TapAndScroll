using System.Security.Cryptography;
using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Application.RepositoryContracts;

namespace TapAndScroll.Infrastructure.Helpers
{
    public class ConfirmHelper(IUserRepository userRepository) : IConfirmHelper
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task CheckToken(int userId, string token)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            
            if (user == null) { return; }

            if (user.ConfirmToken == token)
            {
                user.IsConfirm = true;
                await _userRepository.UpdateUserAsync(user);
            }
        }

        public string GenerateTokenAsync()
        {
            byte[] randomBytes = new byte[32 / 2];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}
