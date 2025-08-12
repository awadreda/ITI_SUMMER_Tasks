using Microsoft.AspNetCore.Mvc;

namespace Tasks_For_ITI_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
