using AssignmentMVC.ViewModels.GridViewModels;
using AssignmentMVC.ViewModels.HomeViewModels;
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
