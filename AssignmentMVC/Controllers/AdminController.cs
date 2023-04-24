using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentMVC.Controllers
{
    [Authorize(Roles = "System Administrator")]
    public class AdminController : Controller
    {
        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}
