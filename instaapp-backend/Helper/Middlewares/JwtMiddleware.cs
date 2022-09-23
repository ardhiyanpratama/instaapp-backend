using instaapp_backend.Core.IConfiguration;
using instaapp_backend.Services.JwtServices;
using Microsoft.Extensions.Options;

namespace instaapp_backend.Helper.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSetting;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSetting)
        {
            _next = next;
            _appSetting = appSetting.Value;
        }

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork, IJwtServices jwtUtils)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var userId = jwtUtils.ValidateJwtToken(token, context);
                if (userId != null)
                {
                    context.Items["User"] = await unitOfWork.Users.GetAsync((long)userId);
                }
            }
            catch
            {

            }

            await _next(context);
        }


    }
}
