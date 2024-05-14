using System.ComponentModel.DataAnnotations;

namespace TapAndScroll.Core.Attributes
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var dbContext = (TapAndScrollDbContext)validationContext.GetService(typeof(TapAndScrollDbContext))
                ?? throw new InvalidOperationException("DbContext не может быть определен.");

            var email = (string)value;

            var user = dbContext.Users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                return new ValidationResult("Пользователь с этой почтой уже существует.");
            }

            return ValidationResult.Success;
        }
    }
}
