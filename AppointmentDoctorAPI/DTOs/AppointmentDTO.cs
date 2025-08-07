using AppointmentDoctorAPI.Models;

namespace AppointmentDoctorAPI.DTOs
{
    public class AppointmentDTO
    {
        public Status Status { get; set; }
        public string Reason { get; set; }
    }
}
