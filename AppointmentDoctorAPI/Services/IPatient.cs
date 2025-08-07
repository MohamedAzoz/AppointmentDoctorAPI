using AppointmentDoctorAPI.Models;

namespace AppointmentDoctorAPI.Services
{
    public interface IPatient
    {
        public void Add(Patient patient);
        public void Update(Patient patient);
        public void Delete(int id);
        public List<Patient> GetAll();
        public Patient GetById(int id);
        public void Save();
    }
}
