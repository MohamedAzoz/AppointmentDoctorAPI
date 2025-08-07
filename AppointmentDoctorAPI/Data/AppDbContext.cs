using AppointmentDoctorAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppointmentDoctorAPI.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AvailableSlot> AvailableSlots { get; set; }

        public AppDbContext(DbContextOptions options):base(options) {}
    }
}
