using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using UserManagement.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using UserManagement.Shared.Constants;

namespace UserManagement.API.Helpers
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata.Any(em => em.GetType() == typeof(AllowAnonymousAttribute));
            
            if (hasAllowAnonymous)
            {
                return;
            }

            var user = context.HttpContext.Items["User"] as UserViewModel;

            if (user == null)
            {
                context.Result = new UnauthorizedResult();

                return;
            }

            if (!string.IsNullOrWhiteSpace(Role) && Role != RoleConstants.Admin && Role != user.Role)
            {
                context.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = 403 };
                return;
            }
        }

        public string Role { get; set; }
    }
}
