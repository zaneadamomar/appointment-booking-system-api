
using appointment_booking_system_api.Model;

namespace appointment_booking_system_api.DAL
{
    public interface IUser
    {
        Task<List<Users>> GetUsers();
    }
}
