namespace Event_Booking_System_MVC.Models;
public class User
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }

    // Navigation
    public ICollection<Booking> Bookings { get; set; }
}
