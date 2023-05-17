//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Options;
//using System.Security.Claims;

//namespace AssignmentMVC.Models.Identity
//{
//    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser>
//    {
//        private readonly UserManager<AppUser> userManager;

//        public CustomClaimsPrincipalFactory(UserManager<AppUser> _userManager, IOptions<IdentityOptions> optionsAccessor) : base(_userManager, optionsAccessor)
//        {
//            userManager = _userManager;
//        }

//        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
//        {
//            var claimsIdentity = await base.GenerateClaimsAsync(user);

//            claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName}", $"{user.LastName}"));


//            return claimsIdentity;
//        }
//    }
//}
