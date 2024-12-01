using CalenderAppService.Models;

namespace CalenderAppService.Service;

public class BookingSlotsService
{
    public List<BookingSlot> CreateTimeSlots()
    {
        int startTime = 9;
        int endTime = 17;
        int hourSplitAmount = 2;
        int timeSlotQty = endTime - startTime;
        List<BookingSlot> bookingSlots = [];
        int index = 0;

        for (int i = startTime; i < startTime + timeSlotQty; i++)
        {
            int increment = HourSplitIncrement(hourSplitAmount);
            int currentTimeSlotMinutes = 0;
            for (int j = 0; j < hourSplitAmount; j++)
            {
                bookingSlots.Add(CreateTimeSlot(index, GetFormattedTime(i, currentTimeSlotMinutes), GetFormattedTime(i, currentTimeSlotMinutes + increment), "available"));
                currentTimeSlotMinutes += increment; index++;
            }
        }

        return bookingSlots;
    }


    #region private methods

    private static BookingSlot CreateTimeSlot(int slotId, string startTime, string endTime, string bookingStatus)
    {
        return new BookingSlot 
        { 
            SlotId = slotId, 
            StartTime = startTime, 
            EndTime = endTime, 
            BookingStatus = bookingStatus 
        };
    }
    private static int HourSplitIncrement(int hourSplitAmount)
    {
        int increment; 
        switch (hourSplitAmount) 
        { 
            case 1: increment = 60; 
                break; 
            case 2: increment = 30; 
                break; 
            case 4: increment = 15; 
                break; 
            default: increment = 60; 
                break; 
        }
        return increment;

    }
    private static string GetFormattedTime(int hour, int minute)
    {
        if (minute == 60) 
        { 
            hour++; 
            minute = 0; 
        }
        return $"{hour:D2}:{minute:D2}";
    }

    #endregion
}
