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

     
    }
}