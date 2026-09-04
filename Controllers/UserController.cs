using appointment_booking_system_api.DAL;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace appointment_booking_system_api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserController : Controller
    {
        private readonly IUser _users;
        public UserController(IUser user)
        {
            _users = user;
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                return Ok(await _users.GetUsers());
            }
            catch (Exception ex)
            {
                Log.Error("GetUsers Exception: {Message}", ex.Message);
                throw;
            }
        }
    }
}
