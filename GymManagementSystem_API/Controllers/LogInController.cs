using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;
using GymManagementSystem_API.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ILogInService _logInService;

        public LogInController(ILogInService logInService)
        {
            _logInService = logInService;
        }

        [HttpPost("MemberLogIn")]
        public async Task<IActionResult> MemberLogIn([FromBody] LogInMemberDTO member)
        {
            try
            {
                var result = await _logInService.MemberLogIn(member);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("MemberSignUp")]
        public async Task<IActionResult> MemberSignUp([FromBody] CreateMemberDTO member)
        {
            try
            {
                var result = await _logInService.MemberSignUp(member);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("ManagerLogIn")]
        public async Task<IActionResult> ManagerLogIn([FromBody] CreateManagerDTO manager)
        {
            try
            {
                var result = await _logInService.ManagerLogIn(manager);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
