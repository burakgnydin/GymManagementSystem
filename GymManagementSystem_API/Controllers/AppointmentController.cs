using Microsoft.AspNetCore.Mvc;
using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Services.Abstracts;

namespace GymManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> GetAppointments()
        {
            var result = await _appointmentService.GetAllAppointmentsAsync();
            if (result.Data == null || result.Data.Count == 0)
            {
                return NotFound("No appointments found.");
            }
            return Ok(result);
        }

        [HttpGet("GetAppointmentById")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            try
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
                return Ok(appointment);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("CreateAppointment")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDTO appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAppointment = await _appointmentService.CreateAppointment(appointment);
            return Ok(createdAppointment);
        }

        [HttpPut("UpdateAppointment")]

        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] EditAppointmentDTO appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest("Appointment ID mismatch.");
            }

            try
            {
                var updatedAppointment = await _appointmentService.UpdateAppointmentAsync(id, appointment);
                return Ok(updatedAppointment);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("DeleteAppointment")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                var deleted = await _appointmentService.DeleteAppointmentAsync(id);
                if (!deleted)
                {
                    return NotFound($"Appointment with ID {id} not found.");
                }
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}