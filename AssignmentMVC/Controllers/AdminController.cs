using AssignmentMVC.Models.Identity;
using AssignmentMVC.ViewModels.UserRolesViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssignmentMVC.Controllers
{
    //[Authorize(Roles = "System Administrator")]
    public class AdminController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        //public async Task<IActionResult> AdminIndex() // Get all Users from database and add to a list.
        //{
        //    var users = await _userManager.Users.ToListAsync();
        //    return View(users);
        //}

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





    }
}
