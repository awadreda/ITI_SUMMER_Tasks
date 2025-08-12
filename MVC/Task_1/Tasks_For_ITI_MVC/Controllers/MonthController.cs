using Microsoft.AspNetCore.Mvc;

namespace Tasks_For_ITI_MVC.Controllers
{
    public class MonthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string monthName)
        {
            string message = "";
            string imagePath = "";

            switch (monthName)
            {
                case "December":
                case "January":
                case "February":
                    message = "You should wear winter clothes";
                    imagePath = "/images/winter.jpg";
                    break;

                case "June":
                case "July":
                case "August":
                    message = "You should wear summer clothes";
                    imagePath = "/images/summer.webp";
                    break;

                default:
                    message = "Mild weather – choose what you like";
                    imagePath = "/images/mild.webp";
                    break;
            }

            ViewBag.Message = message;
            ViewBag.ImagePath = imagePath;
            ViewBag.MonthName = monthName;

            return View();
        }
    }
}
