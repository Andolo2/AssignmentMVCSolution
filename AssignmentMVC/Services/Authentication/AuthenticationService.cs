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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AuthenticationService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _addressService = addressService;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> UserAlreadyExistsAsync(Expression<Func<AppUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }


        public async Task<bool> RegisterUserAsync(UserRegisterViewModel userRegisterViewModel, IFormFile profilePicture)
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

                if (profilePicture != null)
                {
                    appUser.ProfileImageUrl = await SaveProfilePictureAsync(profilePicture);
                    await _userManager.UpdateAsync(appUser);
                }

                return true;
            }

            return false;
        }

        public async Task<string> SaveProfilePictureAsync(IFormFile profilePicture)
        {
            if (profilePicture == null || profilePicture.Length == 0)
            {
                return null; // No file to save
            }

            var uploadsDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images/profilepictures");

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(profilePicture.FileName);
            var filePath = Path.Combine(uploadsDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await profilePicture.CopyToAsync(stream);
            }

            return fileName;
        }






























        ////public async Task<bool> RegisterUserAsync(UserRegisterViewModel userRegisterViewModel)
        ////{
        ////    AppUser appUser = userRegisterViewModel;
        ////    var roleName = "User";

        ////    if (!await _roleManager.Roles.AnyAsync())
        ////    {
        ////        await _roleManager.CreateAsync(new IdentityRole("System Administrator"));
        ////        await _roleManager.CreateAsync(new IdentityRole("User"));
        ////    }


        ////    if (!await _userManager.Users.AnyAsync())
        ////    {
        ////        roleName = "System Administrator";
        ////    }

        ////    var result = await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);
        ////    if (result.Succeeded)
        ////    {
        ////        await _userManager.AddToRoleAsync(appUser, roleName);

        ////        var addressEntity = await _addressService.GetOrCreateAsync(userRegisterViewModel);

        ////        if (addressEntity != null)
        ////        {
        ////            await _addressService.AddAdressAsync(appUser, addressEntity);
        ////        }
        ////        return true;
        ////    }
        ////    return false;


        ////}


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

        public async Task<bool> ChangeUserRoleAsync(string userId, string newRoleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false; // User not found
            }

            var existingRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, existingRoles);
            if (!result.Succeeded)
            {
                return false; // Role removal failed
            }

            result = await _userManager.AddToRoleAsync(user, newRoleName);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false; // User not found
            }

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

    }
}
