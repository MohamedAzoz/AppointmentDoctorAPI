using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentDoctorAPI.Models
{
    public class Dentist
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
        public string ClinicAddress { get; set; }
        public string? ImgURL { get; set; }

        public List<AvailableSlot>? AvailableSlots { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser User { get; set; }

    }
}
