using Microsoft.AspNetCore.Mvc;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Web.Controllers
{
    public class AuthorizeController(IAuthorizeService authorizeService, ILogger<AuthorizeController> logger,
        IEmailService emailService) : Controller
    {
        private readonly IAuthorizeService _authorizeService = authorizeService;
        private readonly ILogger<AuthorizeController> _logger = logger;
        private readonly IEmailService _emailService = emailService;

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UploadRegisterUser model)
        {
            if (ModelState.IsValid)
            {
                var user = await _authorizeService.RegisterAsync(model);

                var textToMail = $"https://localhost:7286/Authorize/Confirm?userId={user.IdUser}&token={user.ConfirmToken}";

                await _emailService.SendEmail(model.Email, textToMail);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public async Task<IActionResult> Confirm(int userId, string token)
        {
            await _authorizeService.ConfirmAsync(userId, token);

            return RedirectToAction("Index", "Home");
        }
    }
}
