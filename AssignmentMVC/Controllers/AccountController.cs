using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentMVC.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult AccountIndex()
        {
            return View();
        }
    }
}
