namespace appointment_booking_system_api.Model
{
    public class BookingConfirmation
    {
        public Guid BookingId { get; set; }
        public string ResultMessage { get; set; }
        public int ResultCode { get; set; }
    }
}
