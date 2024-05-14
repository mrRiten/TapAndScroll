using Microsoft.Extensions.Logging;
using TapAndScroll.Application.ServiceContracts;

namespace TapAndScroll.Infrastructure.Services
{
    public class EmailFakeService(ILogger<EmailFakeService> logger) : IEmailService
    {
        private readonly ILogger<EmailFakeService> _logger = logger;

        public async Task SendEmail(string userEmail, string text)
        {
            _logger.LogWarning($"Send to {userEmail}:\n{text}");
        }
    }
}
