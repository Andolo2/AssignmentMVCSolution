using AssignmentMVC.Models.Identity;
using AssignmentMVC.Services.Authentication;
using AssignmentMVC.ViewModels.UserRolesViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AssignmentMVC.Controllers
{
    [Authorize(Roles = "System Administrator")]
    public class AdminController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly AuthenticationService _auth;

        public AdminController(UserManager<AppUser> userManager, AuthenticationService auth)
        {
            _userManager = userManager;
            _auth = auth;
        }



       
        public async Task<IActionResult> AdminIndex() // Get all Users from database and add to a list.
        {
            var users = await _userManager.Users.ToListAsync();
            var usersWithRoles = new List<UserWithRolesViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var userWithRoles = new UserWithRolesViewModel()
                {
                    User = user,
                    Roles = roles
                };

                usersWithRoles.Add(userWithRoles);
            }

            return View(usersWithRoles);
        }



        //[HttpPost]
        //public async Task<IActionResult> ChangeUserRoleAsync(string userId, string newRoleName) 
        //{
        //    bool result = await _auth.ChangeUserRoleAsync(userId, newRoleName);
        //    if (result)
        //    {
        //        // Role change successful
        //        return RedirectToAction("AdminIndex", "Admin"); 
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Change could not be applied");
        //        return RedirectToAction("AdminIndex", "Admin"); 
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> ChangeUserRoleAsync(string userId, string newRoleName)
        {
            bool result = await _auth.ChangeUserRoleAsync(userId, newRoleName);
            if (result)
            {
                // Role change successful

                // Retrieve the updated user
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    // Add the updated role claim to the user's claims
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, newRoleName));
                }

                return RedirectToAction("AdminIndex", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Change could not be applied");
                return RedirectToAction("AdminIndex", "Admin");
            }
        }



        [HttpPost]
        public async Task<IActionResult> DeleteUserAsync(string userId)
        {
            var success = await _auth.DeleteUserAsync(userId);
            if (success)
            {
                return RedirectToAction("AdminIndex");

            }
            else
            {
                ModelState.AddModelError("", "User not found");
                return RedirectToAction("AdminIndex");

            }
        }

      





    }
}
