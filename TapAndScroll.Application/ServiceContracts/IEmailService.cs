namespace TapAndScroll.Application.ServiceContracts
{
    public interface IEmailService
    {
        public Task SendEmail(string userEmail, string text);
    }
}
