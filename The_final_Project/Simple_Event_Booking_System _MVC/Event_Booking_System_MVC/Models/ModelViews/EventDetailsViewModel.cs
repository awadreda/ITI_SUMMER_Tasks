namespace Event_Booking_System_MVC.Models.ModelViews;

public class EventDetailsViewModel
{
    public int Id { get; set; } // عشان نقدر نعمل Book
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string OrganizerName { get; set; }
    public bool UserHasBooked { get; set; }
}
