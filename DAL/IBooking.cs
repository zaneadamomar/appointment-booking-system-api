using appointment_booking_system_api.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace appointment_booking_system_api.DAL
{
    public interface IBooking
    {
        Task<BookingConfirmation> CreateBooking(Bookings booking);
        Task<BookingConfirmation> RescheduleBooking(Bookings booking);
        Task<BookingConfirmation> CancelBooking(Bookings booking);
        Task<List<Bookings>> GetUserBooking(Guid UserId);
        Task<List<Branch>> GetBranch();
        Task<List<Service>> GetService();
        Task<List<TimeSlot>> GetAvailableTimeSlots(Guid BranchId, Guid ServiceId, string BookingDate);
    }
}
