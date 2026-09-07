namespace appointment_booking_system_api.Model
{
    public class Bookings
    {
        public Guid? BookingId { get; set; }
        public Guid? UserId { get; set; }
        public string? UserName { get; set; } = string.Empty;
        public Guid? BranchId { get; set; }
        public string? BranchName { get; set; } = string.Empty;
        public Guid? ServiceId { get; set; }
        public string? ServiceName { get; set; } = string.Empty;
        public int? DurationMinutes { get; set; }
        public DateTime? BookingDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? StatusId { get; set; }
        public string? Status { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
    }
}
