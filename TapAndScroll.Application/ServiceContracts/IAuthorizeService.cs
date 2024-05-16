using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Application.ServiceContracts
{
    public interface IAuthorizeService
    {
        public Task<User> RegisterAsync(UploadRegisterUser model);
        public Task ConfirmAsync(int userId, string token);

        public Task AuthorizeAsync(string userLogin, string password);
    }
}
