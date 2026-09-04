using appointment_booking_system_api.Model;

namespace appointment_booking_system_api.DAL
{
    public interface IBooking
    {
        Task<BookingConfirmation> CreateBooking(Bookings booking);
        Task<List<Branch>> GetBranch();
        Task<List<Service>> GetService();
    }
}
