using AssignmentMVC.Models.Identity;
using AssignmentMVC.ViewModels.LoginViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AssignmentMVC.Services.Authentication
{
    public class AuthenticationService
    {
        private readonly AddressService _addressService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthenticationService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _addressService = addressService;
            _signInManager = signInManager;
        }

        public async Task<bool> UserAlreadyExistsAsync(Expression<Func<AppUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }

        public async Task<bool> RegisterUserAsync(UserRegisterViewModel userRegisterViewModel)
        {
            AppUser appUser = userRegisterViewModel;

             var result = await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);
            if (result.Succeeded)
            {
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

            if(appUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser, userLoginViewModel.Password, userLoginViewModel.RememberMe, false);
                return result.Succeeded;
            }

            return false;
        }


    }
}
