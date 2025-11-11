using Event_Booking_System_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_Booking_System_MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context) => _context = context;

        public IActionResult Book(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            bool alreadyBooked = _context.Bookings.Any(b => b.EventId == id && b.UserId == userId);
            if (!alreadyBooked)
            {
                _context.Bookings.Add(new Booking { EventId = id, UserId = userId.Value });
                _context.SaveChanges();
            }

            return RedirectToAction("Details", "Event", new { id });
        }

        public IActionResult MyBookings()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var bookings = _context
                .Bookings.Include(b => b.Event)
                .Where(b => b.UserId == userId)
                .ToList();

            return View(bookings);
        }
    }
}
