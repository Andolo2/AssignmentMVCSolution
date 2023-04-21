using AssignmentMVC.ViewModels.LoginViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginIndex(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            ModelState.AddModelError("", "Incorrect Email or Password.");
            return View(userLoginViewModel);
        }
    }
}
