using appointment_booking_system_api.BLL;
using appointment_booking_system_api.DAL;
using appointment_booking_system_api.Model;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpGet("GetAvailableTimeSlots")]
        public async Task<IActionResult> GetAvailableTimeSlots([FromQuery] Guid BranchId, Guid ServiceId, string BookingDate)
        {
            try
            {
                return Ok(await _bookings.GetAvailableTimeSlots(BranchId, ServiceId, BookingDate));
            }
            catch (Exception ex)
            {
                Log.Error("GetAvailableTimeSlots Exception: {Message}", ex.Message);
                throw;
            }
        }

        [HttpPost("GetUserBooking")]
        public async Task<IActionResult> GetUserBooking([FromQuery] Guid UserId)
        {
            try
            {
                return Ok(await _bookings.GetUserBooking(UserId));
            }
            catch (Exception ex)
            {
                Log.Error("GetUserBooking Exception: {Message}", ex.Message);
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
                Log.Error("CreateBooking Exception: {Message}", ex.Message);
                throw;
            }
        }

        [HttpPut("RescheduleBooking")]
        public async Task<IActionResult> RescheduleBooking([FromBody] Bookings bookings)
        {
            try
            {
                return Ok(await _bookings.RescheduleBooking(bookings));
            }
            catch (Exception ex)
            {
                Log.Error("RescheduleBooking Exception: {Message}", ex.Message);
                throw;
            }
        }

        [HttpPost("CancelBooking")]
        public async Task<IActionResult> CancelBooking([FromBody] Bookings bookings)
        {
            try
            {
                return Ok(await _bookings.CancelBooking(bookings));
            }
            catch (Exception ex)
            {
                Log.Error("CancelBooking Exception: {Message}", ex.Message);
                throw;
            }
        }
    }
}
