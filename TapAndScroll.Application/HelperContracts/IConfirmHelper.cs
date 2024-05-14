namespace TapAndScroll.Application.HelperContracts
{
    public interface IConfirmHelper
    {
        public string GenerateTokenAsync();
        public Task CheckToken(int userId, string token);
    }
}
