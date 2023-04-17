using Microsoft.AspNetCore.Mvc;

namespace AssignmentMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomeIndex()
        {
            return View();
        }
    }
}
