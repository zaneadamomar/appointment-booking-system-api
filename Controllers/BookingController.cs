using appointment_booking_system_api.BLL;
using appointment_booking_system_api.DAL;
using appointment_booking_system_api.Model;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace appointment_booking_system_api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BookingController : Controller
    {
        private readonly IBooking _bookings;
        public BookingController(IBooking booking)
        {
            _bookings = booking;
        }

        [HttpGet("GetBranch")]
        public async Task<IActionResult> GetBranch()
        {
            try
            {
                return Ok(await _bookings.GetBranch());
            }
            catch (Exception ex)
            {
                Log.Error("GetBranch Exception: {Message}", ex.Message);
                throw;
            }
        }
        [HttpGet("GetService")]
        public async Task<IActionResult> GetService()
        {
            try
            {
                return Ok(await _bookings.GetService());
            }
            catch (Exception ex)
            {
                Log.Error("GetService Exception: {Message}", ex.Message);
                throw;
            }
        }

        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking([FromBody]Bookings bookings)
        {
            try
            {
                return Ok(await _bookings.CreateBooking(bookings));
            }
            catch (Exception ex)
            {
                Log.Error("GetUsers Exception: {Message}", ex.Message);
                throw;
            }
        }
    }
}
