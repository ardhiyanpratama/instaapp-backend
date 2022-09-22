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

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork, IJwtUtils jwtUtils)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var userId = jwtUtils.ValidateJwtToken(token, context);
                if (userId != null)
                {
                    context.Items["Company"] = await unitOfWork.Companis.GetAsync((long)userId);
                }
            }
            catch
            {

            }

            await _next(context);
        }


    }
}
