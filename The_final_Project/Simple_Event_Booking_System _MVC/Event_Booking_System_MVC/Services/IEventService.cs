using Event_Booking_System_MVC.Models;
using Event_Booking_System_MVC.Models.ModelViews;

namespace Event_Booking_System_MVC.Services;

public interface IEventService
{
    IEnumerable<Event> GetAll();
    Event? GetById(int id);
    Task Create(Event @event);
    Task<Event?> Update(Event @event);
    bool Delete(int id);
}
