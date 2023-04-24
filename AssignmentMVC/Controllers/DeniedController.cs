using Microsoft.AspNetCore.Mvc;

namespace AssignmentMVC.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult DeniedIndex()
        {
            return View();
        }
    }
}
