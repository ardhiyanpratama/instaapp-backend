using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using instaapp_backend.Helper.Identity;

namespace instaapp_backend.Helper.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> _roles;

        public AuthorizeAttribute(params Role[] roles)
        {
            _roles = roles ?? new Role[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            //var user = (Company)context.HttpContext.Items["Company"];
            //if (user is null)
            //{
            //    context.Result = new UnauthorizedResult();
            //}
            //else if (_roles.Any() && !_roles.Contains(user.Role))
            //{
            //    context.Result = new StatusCodeResult(403);
            //}
        }
    }
}
