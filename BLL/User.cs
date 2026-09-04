using appointment_booking_system_api.DAL;
using appointment_booking_system_api.Model;
using Dapper;
using Serilog;
using System.Data;
using System.Data.SqlClient;

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

        public async Task<List<Users>> GetUsers()
        {
            var users = new List<Users>();
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var res = await db.QueryAsync<Users>("dbo.GetUsers", commandType: CommandType.StoredProcedure);
                    users = res.ToList();
                }
                return users;
            }
            
            catch (Exception ex)
            {
                Log.Error("Exception {ex.Message}", ex.Message);
                throw;
            }
        }
    }
}
