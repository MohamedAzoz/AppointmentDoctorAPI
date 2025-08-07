using AppointmentDoctorAPI.Data;
using AppointmentDoctorAPI.Models;
using AppointmentDoctorAPI.Services;

namespace AppointmentDoctorAPI.Repositories
{
    public class DentistRepository : IDentist
    {
        private readonly AppDbContext context;

        public DentistRepository(AppDbContext _Context)
        {
            context = _Context;
        }
        public void Add(Dentist dentist)
        {
            context.Dentists.Add(dentist);
        }

        public void Delete(int id)
        {
            var item=GetById(id);
            context.Dentists.Remove(item);
        }

        public List<Dentist> GetAll()
        {
            return context.Dentists.ToList();
        }

        public Dentist GetById(int id)
        {
            var item=context.Dentists.FirstOrDefault(x=>x.Id==id);
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

        public void Update(Dentist dentist)
        {
            context.Update(dentist);
        }
    }
}
