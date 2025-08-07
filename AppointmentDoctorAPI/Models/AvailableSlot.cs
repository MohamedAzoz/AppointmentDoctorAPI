using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentDoctorAPI.Models
{
    public class AvailableSlot
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public bool IsBooked { get; set; }

        [ForeignKey("Dentist")] 
        public int DentistId { get; set; }
        public Dentist? Dentist { get; set; }

    }
}
