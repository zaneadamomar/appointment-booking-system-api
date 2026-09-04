namespace appointment_booking_system_api.Model
{
    public class Service
    {
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int DurationMinutes { get; set; }
    }
}
