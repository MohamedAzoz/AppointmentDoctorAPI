namespace AppointmentDoctorAPI.DTOs
{
    public class TimesDTO
    {
       public TimeOnly StartTime { get; set; }
       public TimeOnly EndTime { get; set; }
       public DateOnly Date { get; set; }
    }
}
