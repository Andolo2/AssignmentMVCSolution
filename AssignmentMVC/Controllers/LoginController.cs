


using AssignmentMVC.Services.Authentication;
using AssignmentMVC.ViewModels.LoginViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentMVC.Controllers
{
    public class LoginController : Controller
    {

        private readonly AuthenticationService _auth;

        public LoginController(AuthenticationService auth)
        {
            _auth = auth;
        }

        public IActionResult LoginIndex(string ReturnUrl = null!)
        {
            var userLoginViewModel = new UserLoginViewModel();
            if (ReturnUrl != null)
            {
                userLoginViewModel.ReturnUrl = ReturnUrl;
            }
            return View(userLoginViewModel);
        }



        [HttpPost]
        public async Task<IActionResult> LoginIndex(UserLoginViewModel userLoginViewModel)
        {


            if (ModelState.IsValid)
            {
                if (await _auth.LoginAsync(userLoginViewModel))
                    return LocalRedirect(userLoginViewModel.ReturnUrl);
                ModelState.AddModelError("", "Incorrect Email or Password.");

            }


            return View(userLoginViewModel);
        }


    }
}
