using AssignmentMVC.Services.Authentication;
using AssignmentMVC.ViewModels.LoginViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AssignmentMVC.Controllers
{
    public class RegisterController : Controller
    {
        private readonly  AuthenticationService _auth;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RegisterController(AuthenticationService auth, IWebHostEnvironment webHostEnvironment)
        {
            _auth = auth;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult RegisterIndex()
        {
            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> RegisterIndex(UserRegisterViewModel userRegisterViewModel, IFormFile profilePicture)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.UserAlreadyExistsAsync(x => x.Email == userRegisterViewModel.Email))
                    ModelState.AddModelError("", "User with this email exists");

                if (await _auth.RegisterUserAsync(userRegisterViewModel, profilePicture))
                {
                    return RedirectToAction("LoginIndex", "Login");
                }
            }

            return View(userRegisterViewModel);
        }

        //public async Task<IActionResult> RegisterIndex(UserRegisterViewModel userRegisterViewModel)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if(await _auth.UserAlreadyExistsAsync(x => x.Email == userRegisterViewModel.Email))
        //            ModelState.AddModelError("", "User with this email exists");


        //        if (await _auth.RegisterUserAsync(userRegisterViewModel))
        //        {
        //            return RedirectToAction("LoginIndex", "Login");
        //        }


        //    }
        //    return View(userRegisterViewModel);
        //}


    }
}
