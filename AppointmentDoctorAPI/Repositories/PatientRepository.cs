using AppointmentDoctorAPI.Data;
using AppointmentDoctorAPI.Models;
using AppointmentDoctorAPI.Services;

namespace AppointmentDoctorAPI.Repositories
{
    public class PatientRepository : IPatient
    {
        private readonly AppDbContext context;

        public PatientRepository(AppDbContext _Context)
        {
            context = _Context;
        }
        public void Add(Patient patient)
        {
            context.Patients.Add(patient);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            context.Patients.Remove(item);
        }

        public List<Patient> GetAll()
        {
            return context.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            var item=context.Patients.FirstOrDefault(x=>x.Id==id);
            if (item!=null)
            {
                return item;
            }
            throw new Exception("Not Found");
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Patient patient)
        {
            context.Update(patient);
        }
    }
}
