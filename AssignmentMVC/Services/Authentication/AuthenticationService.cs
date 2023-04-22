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

        public AuthenticationService(UserManager<AppUser> userManager, AddressService addressService)
        {
            _userManager = userManager;
            _addressService = addressService;
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


    }
}
