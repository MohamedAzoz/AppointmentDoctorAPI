using AppointmentDoctorAPI.Models;

namespace AppointmentDoctorAPI.Services
{
    public interface IAppointment
    {
        public void Add(Appointment appointment);
        public void Update(Appointment appointment);
        public void Delete(int id);
        public List<Appointment> GetAll();
        public Appointment GetById(int id);
        public void Save();
    }
}
