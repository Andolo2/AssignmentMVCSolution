////namespace AssignmentMVC.AuthFilters
////{
////    using System.Security.Claims;
////    using System.Threading.Tasks;
////    using Microsoft.AspNetCore.Authorization;
////    using Microsoft.AspNetCore.Http;
////    using Microsoft.Extensions.Logging;

////    public class LoggingAuthorizationHandler : AuthorizationHandler<IAuthorizationRequirement>
////    {
////        private readonly IHttpContextAccessor _httpContextAccessor;
////        private readonly ILogger<LoggingAuthorizationHandler> _logger;

////        public LoggingAuthorizationHandler(IHttpContextAccessor httpContextAccessor, ILogger<LoggingAuthorizationHandler> logger)
////        {
////            _httpContextAccessor = httpContextAccessor;
////            _logger = logger;
////        }

////        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IAuthorizationRequirement requirement)
////        {
////            var httpContext = _httpContextAccessor.HttpContext;
////            var policyName = context.Policy?.AuthenticationSchemes ?? "[Default]";
////            var roles = context.User?.FindAll(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

////            _logger.LogInformation($"Authorization Policy '{policyName}' evaluated for user '{context.User?.Identity?.Name}'. Roles: {string.Join(", ", roles)}");

////            return Task.CompletedTask;
////        }
////    }

////}
