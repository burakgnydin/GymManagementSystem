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

        [HttpPost]
        public IActionResult CreateMember(CreateMemberDTO request)
        {
            var result = _memberService.CreateMember(request);
            return Ok(result);
        }

        [HttpPut("UpdateMember")]
        public IActionResult UpdateMember(EditMemberDTO request)
        {
            var result = _memberService.UpdateMember(request);
            return Ok(result);
        }

        [HttpPut("SetMemberInfo")]
        public IActionResult EditMemberInfo(EditMemberInfoDTO request)
        {
            var result = _memberService.EditMemberInfo(request);
            return Ok(result);
        }
    }
}
