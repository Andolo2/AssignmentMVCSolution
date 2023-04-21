using AssignmentMVC.ViewModels.LoginViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentMVC.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult RegisterIndex()
        {
            return View();
        }

        [HttpPost]

        public IActionResult RegisterIndex(UserRegisterViewModel userRegisterViewModel)
        {

            if (ModelState.IsValid)
            {
                return View();
            }
            return View(userRegisterViewModel);
        }
           
        
    }
}
