using Event_Booking_System_MVC.Models;
using Event_Booking_System_MVC.Models.ModelViews;
using Event_Booking_System_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Event_Booking_System_MVC.Controllers;

public class EventController : Controller
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    public IActionResult Index()
    {
        var events = _eventService.GetAll();
        return View(events);
    }

    public IActionResult Details(int id)
    {
        var @event = _eventService.GetById(id);
        if (@event == null)
            return NotFound();

        int? userId = HttpContext.Session.GetInt32("UserId");
        bool hasBooked = userId != null && @event.Bookings.Any(b => b.UserId == userId);

        var model = new EventDetailsViewModel
        {
            Id = @event.Id,
            Title = @event.Title,
            Description = @event.Description,
            Date = @event.Date,
            OrganizerName = @event.OrganizerName,
            UserHasBooked = hasBooked,
        };

        return View(model);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Event @event)
    {
        if (ModelState.IsValid)
        {
            await _eventService.Create(@event);
            return RedirectToAction("Index");
        }
        return View(@event);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var @event = _eventService.GetById(id);
        return @event == null ? NotFound() : View(@event);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Event @event)
    {
        if (id != @event.Id)
            return BadRequest();

        if (!ModelState.IsValid)
        {
            // Debug: اعرض كل الأخطاء
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View(@event);
        }

        var updated = await _eventService.Update(@event);
        if (updated == null)
            return NotFound();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        _eventService.Delete(id);
        return RedirectToAction("Index");
    }
}
