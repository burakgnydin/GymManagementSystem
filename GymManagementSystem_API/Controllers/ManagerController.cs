using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Services.Abstracts;
using Microsoft.AspNetCore.Http;
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
        public IActionResult GetMembers()
        {
            var result = _managerService.GetAllMembers();
            return Ok(result);
        }

        [HttpGet("GetUniqueMember")]
        public IActionResult GetMember(EditMemberDTO member)
        {
            var result = _managerService.GetMemberById(member);
            return Ok(result);
        }

        [HttpDelete("DeleteMember")]
        public IActionResult DeleteMember(EditMemberDTO member) 
        {
            var result = _managerService.DeleteMember(member);
            return Ok(result);
        }


        [HttpPut("UpdateManager")]
        public IActionResult UpdateManager(EditManagerDTO request)
        {
            var result = _managerService.UpdateManager(request);
            return Ok(result);
        }
    }
}
