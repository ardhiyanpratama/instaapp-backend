using System.Net.Http.Headers;
using System.Text;

namespace instaapp_backend.Helper.Middlewares
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
        {
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                var username = credentials[0];
                var apiKey = credentials[1];
                var user = await unitOfWork.Companis.AuthenticateUsingApiKeyAsync(username, apiKey);

                context.Items["Company"] = user;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            await _next(context);
        }

    }
}
