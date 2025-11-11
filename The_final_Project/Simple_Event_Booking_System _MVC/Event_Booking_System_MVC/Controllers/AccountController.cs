using Event_Booking_System_MVC.Models;
using Event_Booking_System_MVC.Models.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_Booking_System_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // Register
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (_context.Users.Any(u => u.UserName == model.UserName))
            {
                ModelState.AddModelError("", "User already exists");
                return View();
            }

            var user = new User { UserName = model.UserName, Password = model.Password };
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        // Login
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _context.Users.FirstOrDefault(u =>
                u.UserName == model.UserName && u.Password == model.Password
            );
            if (user == null)
            {
                model.ErrorMessage = "Invalid username or password";
                return View(model);
            }

            // Store user id in session
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.UserName);

            return RedirectToAction("Index", "Home");
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
