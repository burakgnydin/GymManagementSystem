using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Services.Abstracts;
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

        [HttpGet("GetUniqueMember")]
        public async Task<IActionResult> GetMember(EditMemberDTO member)
        {
            var result = await _managerService.GetMemberById(member);
            return Ok(result);
        }

        [HttpDelete("DeleteMember")]
        public async Task<IActionResult> DeleteMember(EditMemberDTO member) 
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
    }
}
