namespace CalenderAppService.Models;

public class BookingSlot 
{ 
    public int SlotId { get; set; }
    public string StartTime { get; set; } 
    public string EndTime { get; set; } 
    public string BookingStatus { get; set; } 
}
