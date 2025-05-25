using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPut("UpdateMember")]
        public async Task<IActionResult> UpdateMember(EditMemberDTO request)
        {
            var result = await _memberService.UpdateMember(request);
            return Ok(result);
        }

        [HttpPut("SetMemberInfo")]
        public async Task<IActionResult> EditMemberInfo(EditMemberInfoDTO request)
        {
            var result = await _memberService.EditMemberInfo(request);
            return Ok(result);
        }

        [HttpPut("GetAllAppointmentsById")]
        public async Task<IActionResult> GetAppointments(GetAppointmentDto appointment)
        {
            var result = await _memberService.GetAllAppointmentsByIdAsync(appointment);
            if (result.Data == null || result.Data.Count == 0)
            {
                return NotFound("No appointments found.");
            }
            return Ok(result);
        }

        [HttpPost("CreateAppointment")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDto appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAppointment = await _memberService.CreateAppointment(appointment);
            return Ok(createdAppointment);
        }

        [HttpDelete("DeleteAppointment")]
        public async Task<IActionResult> DeleteAppointment(GetAppointmentDto appointment)
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

        [HttpPut("EditAmountOfWater")]
        public async Task<IActionResult> EditEmountOfWater(UpdateWaterDTO water)
        {
            var result = await _memberService.EditAmountOfWaterAsync(water);
            return Ok(result);
        }

        [HttpGet("GetAllTrainers")]
        public async Task<IActionResult> GetAlltrainers()
        {
            var result = await _memberService.GetAllTrainersAsync();
            return Ok(result);
        }

        [HttpPut("ChooseTrainer")]
        public async Task<IActionResult> ChooseTrainer(ChooseTrainerDto trainer)
        {
            var result = await _memberService.ChooseTrainerAsync(trainer);
            return Ok(result);
        }

        [HttpPut("GetBodyType")]
        public async Task<IActionResult> GetBodyType (GetMemberDto request)
        {
            var result = await _memberService.GetBodyTypeAsync(request);
            return Ok(result);  
        }
    }
}
