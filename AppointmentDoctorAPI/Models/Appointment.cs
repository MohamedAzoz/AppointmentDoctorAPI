using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentDoctorAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Reason { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        [ForeignKey("AvailableSlot")]
        public int SlotId { get; set; }
        public AvailableSlot? AvailableSlot { get; set; }
    }
}
