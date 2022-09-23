using instaapp_backend.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace instaapp_backend.Services.JwtServices
{
    public interface IJwtServices
    {
        public string GenerateJwtToken(User user, HttpContext httpContext);
        public long? ValidateJwtToken(string token, HttpContext httpContext);
    }
}
