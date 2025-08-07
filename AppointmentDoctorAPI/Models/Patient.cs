using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentDoctorAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public List<Appointment>? Appointments { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
