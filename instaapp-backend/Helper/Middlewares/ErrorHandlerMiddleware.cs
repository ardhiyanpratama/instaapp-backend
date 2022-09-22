using instaapp_backend.Helper.Exceptions;
using Newtonsoft.Json;

namespace instaapp_backend.Helper.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (ex)
                {
                    case AppException:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case KeyNotFoundException:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    case MemberAccessException:
                        response.StatusCode = StatusCodes.Status403Forbidden;
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                var result = JsonConvert.SerializeObject(new ResponseMessage
                {
                    Header = ResponseMessageExtensions.DEFAULT_HEADER_ERROR,
                    Note = ex?.Message
                });

                await response.WriteAsync(result);
            }
        }

    }
}
