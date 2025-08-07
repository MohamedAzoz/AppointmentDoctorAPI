using AppointmentDoctorAPI.Models;

namespace AppointmentDoctorAPI.Services
{
    public interface IDentist
    {
        public void Add(Dentist dentist);
        public void Update(Dentist dentist);
        public void Delete(int id);
        public List<Dentist> GetAll();
        public Dentist GetById(int id);
        public void Save();
    }
}
