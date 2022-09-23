using instaapp_backend.Helper;
using instaapp_backend.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace instaapp_backend.Services.JwtServices
{
    public class JwtServices : IJwtServices
    {
        private readonly AppSettings _appSetting;
        public JwtServices(IOptions<AppSettings> appSetting)
        {
            _appSetting = appSetting.Value;
        }
        public string GenerateJwtToken(User user, HttpContext httpContext)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString())
                }),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = httpContext.Request.Headers.Host
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public long? ValidateJwtToken(string token, HttpContext httpContext)
        {
            throw new NotImplementedException();
        }
    }
}
