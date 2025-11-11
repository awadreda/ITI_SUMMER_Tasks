namespace Event_Booking_System_MVC.Models;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string OrganizerName { get; set; }

    // Navigation
    public ICollection<Booking>? Bookings { get; set; }
}
