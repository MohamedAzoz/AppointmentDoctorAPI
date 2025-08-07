using AppointmentDoctorAPI.DTOs;
using AppointmentDoctorAPI.Models;

namespace AppointmentDoctorAPI.Services
{
    public interface IAvailableSlot
    {
        public void Add(AvailableSlot slot);
        public void Update(AvailableSlot slot);
        public bool UpdateByTime(TimesDTO times);
        public void Delete(int id);
        public List<AvailableSlot> GetAll();
        public AvailableSlot GetById(int id);
        public void Save();
    }
}
