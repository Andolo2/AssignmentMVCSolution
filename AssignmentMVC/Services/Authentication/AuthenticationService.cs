using AssignmentMVC.Models.Identity;
using AssignmentMVC.ViewModels.LoginViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;

namespace AssignmentMVC.Services.Authentication
{
    public class AuthenticationService
    {
        private readonly AddressService _addressService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
     
        public AuthenticationService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _addressService = addressService;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        public async Task<bool> UserAlreadyExistsAsync(Expression<Func<AppUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }

        public async Task<bool> RegisterUserAsync(UserRegisterViewModel userRegisterViewModel)
        {
            AppUser appUser = userRegisterViewModel;
            var roleName = "User";

            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("System Administrator"));
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }


            if (!await _userManager.Users.AnyAsync())
            {
                roleName = "System Administrator";
            }

            var result = await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, roleName);

                var addressEntity = await _addressService.GetOrCreateAsync(userRegisterViewModel);

                if (addressEntity != null)
                {
                    await _addressService.AddAdressAsync(appUser, addressEntity);
                }
                return true;
            }
            return false;


        }





        public async Task<bool> LoginAsync(UserLoginViewModel userLoginViewModel)
        {
            var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == userLoginViewModel.Email);

            if (appUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser, userLoginViewModel.Password, userLoginViewModel.RememberMe, false);
                return result.Succeeded;
            }

            return false;
        }


    }
}
