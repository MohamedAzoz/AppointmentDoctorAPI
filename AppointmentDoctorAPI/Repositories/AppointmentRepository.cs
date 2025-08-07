using AppointmentDoctorAPI.Data;
using AppointmentDoctorAPI.Models;
using AppointmentDoctorAPI.Services;

namespace AppointmentDoctorAPI.Repositories
{
    public class AppointmentRepository : IAppointment
    {
        private readonly AppDbContext context;

        public AppointmentRepository(AppDbContext _Context)
        {
            context = _Context;
        }
        public void Add(Appointment appointment)
        {
            context.Add(appointment);
        }

        public void Delete(int id)
        {
            var item=GetById(id);
            context.Remove(item);
        }

        public List<Appointment> GetAll()
        {
            return context.Appointments.ToList();
        }

        public Appointment GetById(int id)
        {
            var item=context.Appointments.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                return item;
            }
            throw new Exception("Not Found");
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            context.Update(appointment);
        }
    }
}
