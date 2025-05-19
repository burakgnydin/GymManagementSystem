using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Services.Abstracts;
using GymManagementSystem_API.Services.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet("GetAllMembers")]
        public async Task<IActionResult> GetMembers()
        {
            var result = await _managerService.GetAllMembers();
            return Ok(result);
        }

        [HttpPut("GetUniqueMember")]
        public async Task<IActionResult> GetMember(GetMemberDto member)
        {
            var result = await _managerService.GetMemberById(member);
            return Ok(result);
        }

        [HttpDelete("DeleteMember")]
        public async Task<IActionResult> DeleteMember(GetMemberDto member) 
        {
            var result = await _managerService.DeleteMember(member);
            return Ok(result);
        }


        [HttpPut("UpdateManager")]
        public async Task<IActionResult> UpdateManager(EditManagerDTO request)
        {
            var result = await _managerService.UpdateManager(request);
            return Ok(result);
        }

        [HttpPut("GetAppointmentById")]
        public async Task<IActionResult> GetAppointment(GetAppointmentDto appointment)
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

        [HttpPut("GetIdByEmail")]
        public async Task <IActionResult> GetIdByEmail(GetIdDto email)
        {
            try
            {
                var result = await _managerService.GetIdByEmailAsync(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> GetAppointments()
        {
            var result = await _managerService.GetAllAppointmentsAsync();
            if (result.Data == null || result.Data.Count == 0)
            {
                return NotFound("No appointments found.");
            }
            return Ok(result);
        }

        [HttpPut("SetMemberShipPeriod")]
        public async Task<IActionResult> SetMemberShipPeriod(MemberShipDTO request)
        {
            await _managerService.SetMembershipPeriod(request);
            return Ok();
        }

        [HttpPost("CreateTrainer")]
        public async Task<IActionResult> CreateTrainer([FromBody] CreateTrainerDto trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTrainer = await _managerService.CreateTrainerAsync(trainer);
            return Ok(createdTrainer);
        }

        [HttpDelete("DeleteTrainer")]
        public async Task<IActionResult> DeleteTrainer(GetTrainerDto trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deletedObj = await _managerService.DeleteTrainerAsync(trainer);
            return Ok(deletedObj);
        }

    }
}
