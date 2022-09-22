using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace instaapp_backend.Services.JwtServices
{
    public interface IJwtServices
    {
        public string GenerateJwtToken(Company company, HttpContext httpContext);
        public long? ValidateJwtToken(string token, HttpContext httpContext);
    }
}
