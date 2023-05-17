using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace AssignmentMVC.AuthFilters
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        private readonly ILogger<CustomAuthorizationFilter> _logger;
        private readonly string _roles;

        public CustomAuthorizationFilter(string roles, ILogger<CustomAuthorizationFilter> logger)
        {
            _roles = roles;
            _logger = logger;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                // User is not authenticated
                _logger.LogInformation("User is not authenticated.");
                return;
            }

            if (!string.IsNullOrEmpty(_roles))
            {
                if (!context.HttpContext.User.IsInRole(_roles))
                {
                    // User does not have the required role
                    var userRoles = context.HttpContext.User.FindFirstValue(ClaimTypes.Role);
                    _logger.LogInformation($"Access denied. User '{context.HttpContext.User.Identity.Name}' with role '{userRoles}' does not have the required role '{_roles}'.");
                    context.Result = new ForbidResult();
                    return;
                }
            }

            // User is authorized
            var userRole = context.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            _logger.LogInformation($"User '{context.HttpContext.User.Identity.Name}' is authorized with role '{userRole}'.");
        }
    }
}
