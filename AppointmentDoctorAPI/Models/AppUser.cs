using Microsoft.AspNetCore.Identity;

namespace AppointmentDoctorAPI.Models
{
    public class AppUser : IdentityUser
    {
       
        public Dentist? Dentist { get; set; }

        public Patient? Patient { get; set; }
    }
}
