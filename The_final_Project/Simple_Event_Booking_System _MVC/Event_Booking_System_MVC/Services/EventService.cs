using Event_Booking_System_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Booking_System_MVC.Services;

public class EventService : IEventService
{
    private readonly AppDbContext _context;

    public EventService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Event> GetAll()
    {
        return _context.Events.Include(e => e.Bookings).AsNoTracking().ToList();
    }

    public Event? GetById(int id)
    {
        return _context.Events.Include(e => e.Bookings).SingleOrDefault(e => e.Id == id);
    }

    public async Task Create(Event @event)
    {
        _context.Events.Add(@event);
        await _context.SaveChangesAsync();
    }

    public async Task<Event?> Update(Event @event)
    {
        var existingEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == @event.Id);
        if (existingEvent == null)
            return null;

        existingEvent.Title = @event.Title;
        existingEvent.Description = @event.Description;
        existingEvent.Date = @event.Date;
        existingEvent.OrganizerName = @event.OrganizerName;

        await _context.SaveChangesAsync();
        return existingEvent;
    }

    public bool Delete(int id)
    {
        var existingEvent = _context.Events.Find(id);
        if (existingEvent == null)
            return false;

        _context.Events.Remove(existingEvent);
        return _context.SaveChanges() > 0;
    }
}
