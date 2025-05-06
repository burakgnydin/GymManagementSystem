using Microsoft.AspNetCore.Mvc;
using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Services.Abstracts;
using GymManagementSystem_API.Services.Concretes;
using GymManagementSystem_API.Entity;

namespace GymManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IManagerService _managerService;

        public AppointmentController(IMemberService appointmentService, IManagerService managerService)
        {
            _memberService = appointmentService;
            _managerService = managerService;
        }

        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> GetAppointments()
        {
            var result = await _memberService.GetAllAppointmentsAsync();
            if (result.Data == null || result.Data.Count == 0)
            {
                return NotFound("No appointments found.");
            }
            return Ok(result);
        }

        [HttpGet("GetAppointmentById")]
        public async Task<IActionResult> GetAppointment(EditAppointmentDTO appointment)
        {
            try
            {
                var result = await _managerService.GetAppointmentByIdAsync(appointment);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("CreateAppointment")]
        public async Task<IActionResult> CreateAppointment([FromBody] EditAppointmentDTO appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAppointment = await _memberService.CreateAppointment(appointment);
            return Ok(createdAppointment);
        }

        

        [HttpDelete("DeleteAppointment")]
        public async Task<IActionResult> DeleteAppointment(EditAppointmentDTO appointment)
        {
            try
            {
                var deleted = await _memberService.DeleteAppointmentAsync(appointment);
                if (!deleted)
                {
                    return NotFound($"Appointment with ID {appointment.Id} not found.");
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