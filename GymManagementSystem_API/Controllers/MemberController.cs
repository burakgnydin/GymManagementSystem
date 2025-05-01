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

        [HttpGet("GetAllMembers")]
        public IActionResult GetMembers()
        {
            var result = _memberService.GetAllMembers();
            return Ok(result);
        }

        [HttpGet("GetUniqueMember")]
        public IActionResult GetMember(int id)
        {
            var result = _memberService.GetMemberById(id);
            return Ok(result);
        }

        [HttpDelete("DeleteMember")]
        public IActionResult DeleteMember(int id) 
        {
            var result = _memberService.DeleteMember(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMember(CreateMemberDTO request)
        {
            var result = _memberService.CreateMember(request);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCategory(EditMemberDTO request)
        {
            var result = _memberService.UpdateMember(request);
            return Ok(result);
        }
    }
}
