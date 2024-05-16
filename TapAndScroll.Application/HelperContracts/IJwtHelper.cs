using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Application.HelperContracts
{
    public interface IJwtHelper
    {
        public string GenerateJwtToken(UploadAuthorizeModel model);
    }
}
