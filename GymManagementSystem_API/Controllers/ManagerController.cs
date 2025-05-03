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
        public IActionResult GetMember(int id)
        {
            var result = _managerService.GetMemberById(id);
            return Ok(result);
        }

        [HttpDelete("DeleteMember")]
        public IActionResult DeleteMember(int id) 
        {
            var result = _managerService.DeleteMember(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateManager(CreateManagerDTO request)
        {
            var result = _managerService.CreateManager(request);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateManager(EditManagerDTO request)
        {
            var result = _managerService.UpdateManager(request);
            return Ok(result);
        }
    }
}
