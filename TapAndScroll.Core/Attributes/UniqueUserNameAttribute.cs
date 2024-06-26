﻿using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Attributes
{
    public class UniqueUserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var dbContext = (TapAndScrollDbContext)validationContext.GetService(typeof(TapAndScrollDbContext))
                ?? throw new InvalidOperationException("DbContext не может быть определен.");

            var userName = (string)value;

            var user = dbContext.Users.FirstOrDefault(u => u.UserName == userName);

            if (user != null)
            {
                return new ValidationResult("Пользователь с таким именем уже существует.");
            }

            return ValidationResult.Success;
        }
    }
}
