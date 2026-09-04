using appointment_booking_system_api.DAL;
using appointment_booking_system_api.Model;

namespace appointment_booking_system_api.BLL
{
    public class User : IUser
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;
        public User(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public Task<List<Users>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
