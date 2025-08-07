using AppointmentDoctorAPI.DTOs;
using AppointmentDoctorAPI.Models;
using AppointmentDoctorAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentDoctorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAvailableSlot availableSlot;
        private readonly IAppointment appointment;

        public AppointmentController(IAvailableSlot _availableSlot,IAppointment _appointment)
        {
            availableSlot = _availableSlot;
            appointment = _appointment;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var item = appointment.GetAll();
            return Ok(item);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = appointment.GetById(id);
            AppointmentDTO App = new AppointmentDTO();
            App.Reason = item.Reason;
            App.Status = item.Status;
            return Ok(App);
        }

        [HttpPost]
        public IActionResult Add(Appointment slot)
        {
            appointment.Add(slot);
            appointment.Save();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, AppointmentDTO dTO)
        {
            var item = appointment.GetById(id);
            if (item == null)
            {
                return NotFound("Not Found");
            }
            item.Status = dTO.Status;
            item.Reason = dTO.Reason;
            appointment.Update(item);
            appointment.Save();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            appointment.Delete(id);
            appointment.Save();
            return NoContent();
        }

    }
}
