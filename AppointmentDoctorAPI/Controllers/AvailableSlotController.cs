using AppointmentDoctorAPI.DTOs;
using AppointmentDoctorAPI.Models;
using AppointmentDoctorAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentDoctorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableSlotController : ControllerBase
    {
        private readonly IAvailableSlot availableSlot;

        public AvailableSlotController(IAvailableSlot _availableSlot)
        {
            availableSlot = _availableSlot;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var item = availableSlot.GetAll();
            return Ok(item);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = availableSlot.GetById(id);
            AvailableSlotDTO slotDTO = new AvailableSlotDTO();
            slotDTO.StartTime=item.StartTime;
            slotDTO.EndTime=item.EndTime;
            slotDTO.Date=item.Date;
            slotDTO.IsBooked=item.IsBooked;
            return Ok(slotDTO);
        }

        [HttpPost]
        public IActionResult Add(AvailableSlot slot)
        {
            availableSlot.Add(slot);
            availableSlot.Save();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, AvailableSlotDTO slot)
        {
            var item = availableSlot.GetById(id);
            if (item == null)
            {
                return NotFound("Not Found");
            }
            item.StartTime = slot.StartTime;
            item.EndTime = slot.EndTime;
            item.Date = slot.Date;
            item.IsBooked = slot.IsBooked;
            availableSlot.Update(item);
            availableSlot.Save();
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateByTime(TimesDTO times)
        {
            var item = availableSlot.UpdateByTime(times);
            if (item == false)
            {
                return NotFound("Not Found");
            }
            availableSlot.Save();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            availableSlot.Delete(id);
            availableSlot.Save();
            return NoContent();
        }

    }
}
