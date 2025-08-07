namespace AppointmentDoctorAPI.DTOs
{
    public class AvailableSlotDTO
    {
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public bool IsBooked { get; set; }
    }
}
