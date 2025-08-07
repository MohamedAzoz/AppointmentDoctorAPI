using AppointmentDoctorAPI.Data;
using AppointmentDoctorAPI.DTOs;
using AppointmentDoctorAPI.Models;
using AppointmentDoctorAPI.Services;

namespace AppointmentDoctorAPI.Repositories
{
    public class AvailableSlotRepository : IAvailableSlot
    {
        private readonly AppDbContext context;

        public AvailableSlotRepository(AppDbContext _Context)
        {
            context = _Context;
        }
        public void Add(AvailableSlot slot)
        {
            context.Add(slot);
        }

        public void Delete(int id)
        {
            var item=GetById(id);
            context.Remove(item);
        }

        public List<AvailableSlot> GetAll()
        {
            return context.AvailableSlots.ToList();
        }

        public AvailableSlot GetById(int id)
        {
            var item=context.AvailableSlots.FirstOrDefault(x => x.Id == id);
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

        public void Update(AvailableSlot slot)
        {
            context.Update(slot);
        }

        public bool UpdateByTime(TimesDTO times)
        {
           var item=context.AvailableSlots.FirstOrDefault(x=>x.StartTime==times.StartTime 
                                                && x.EndTime==times.EndTime && x.Date==times.Date);
            if (item != null)
            {
                item.IsBooked = true;
                context.Update(item);
                return true;
            }
            return false;
        }
    }
}
