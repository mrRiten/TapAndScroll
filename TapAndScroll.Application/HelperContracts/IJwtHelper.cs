using TapAndScroll.Core.Models;

namespace TapAndScroll.Application.HelperContracts
{
    public interface IJwtHelper
    {
        public string GenerateJwtToken(User model);
    }
}
