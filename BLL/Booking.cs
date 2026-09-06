using appointment_booking_system_api.DAL;
using appointment_booking_system_api.Model;
using Dapper;
using Serilog;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace appointment_booking_system_api.BLL
{
    public class Booking : IBooking
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;
        public Booking(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<BookingConfirmation> CreateBooking(Bookings booking)
        {
            var result = new BookingConfirmation();
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var response = await db.QueryAsync<BookingConfirmation>("dbo.CreateBooking", new
                    {
                        @UserId = booking.UserId,
                        @BranchId = booking.BranchId,
                        @ServiceId = booking.ServiceId,
                        @BookingDate = booking.BookingDate,
                        @StartTime = booking.StartTime

                    }, commandType: CommandType.StoredProcedure);

                    result = new BookingConfirmation
                    {
                        ResultCode = response.FirstOrDefault().ResultCode,
                        ResultMessage = response.FirstOrDefault().ResultMessage,
                        BookingId = response.FirstOrDefault().BookingId
                    };
                }
            }
            catch (Exception ex)
            {
                Log.Error("CreateBooking {ex.Message}", ex.Message);
                result = new BookingConfirmation
                {
                    ResultCode = 100,
                    ResultMessage = ex.Message,
                    BookingId = Guid.Empty
                };
            }
            return result;
        }

        public async Task<List<Branch>> GetBranch()
        {
            var result = new List<Branch>();
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var response = await db.QueryAsync<Branch>("dbo.GetBranches", commandType: CommandType.StoredProcedure);
                    result = response.ToList();
                }
            }
            catch (Exception ex)
            {

                Log.Error("GetBranch {ex.Message}", ex.Message);
            }
            return result;
        }

        public async Task<List<Service>> GetService()
        {
            var result = new List<Service>();
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var response = await db.QueryAsync<Service>("dbo.GetServices", commandType: CommandType.StoredProcedure);
                    result = response.ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetService {ex.Message}", ex.Message);
            }
            return result;
        }

        public async Task<List<TimeSlot>> GetAvailableTimeSlots(Guid BranchId, Guid ServiceId, string BookingDate)
        {
            var result = new List<TimeSlot>();
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var response = await db.QueryAsync<TimeSlot>("dbo.GetAvailableTimeSlots",new 
                    {
                        @BranchId = BranchId,
                        @ServiceId = ServiceId,
                        @BookingDate = DateTime.Parse(BookingDate)
                    }, commandType: CommandType.StoredProcedure);
                    result = response.ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetAvailableTimeSlots {ex.Message}", ex.Message);
            }
            return result;
        }
    }
}
