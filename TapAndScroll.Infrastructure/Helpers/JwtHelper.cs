using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Helpers
{
    public class JwtHelper(IOptions<JwtOptions> options) : IJwtHelper
    {
        private readonly JwtOptions _options = options.Value;

        public string GenerateJwtToken(User model)
        {
            Claim[] claims = [new("userId", model.IdUser.ToString()),
                new Claim(ClaimTypes.Role, model.Role.RoleName)];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                issuer: _options.Issuer,
                expires: DateTime.Now.AddHours(_options.ExpiatesHours));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
