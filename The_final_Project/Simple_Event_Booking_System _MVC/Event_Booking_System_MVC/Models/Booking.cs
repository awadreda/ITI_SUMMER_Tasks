namespace Event_Booking_System_MVC.Models;

public class Booking
{
    public int Id { get; set; }

    // Foreign Keys
    public int UserId { get; set; }
    public int EventId { get; set; }

    // Navigation
    public User User { get; set; }
    public Event Event { get; set; }
}
