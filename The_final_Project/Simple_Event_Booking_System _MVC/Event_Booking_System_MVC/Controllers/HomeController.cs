using Microsoft.AspNetCore.Mvc;

namespace Event_Booking_System_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
                return RedirectToAction("Login", "Account");

            ViewBag.UserName = userName;
            return View();
        }
    }
}
