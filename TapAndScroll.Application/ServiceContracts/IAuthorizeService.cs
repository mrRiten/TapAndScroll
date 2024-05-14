﻿using System.Security.Claims;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Application.ServiceContracts
{
    public interface IAuthorizeService
    {
        public Task<User> RegisterAsync(UploadRegisterUser model);
        public Task<bool> ValidateAsync(UploadRegisterUser model);
        public Task ConfirmAsync(int userId, string token);
    }
}
