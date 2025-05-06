using GymManagementSystem_API.DTO;

namespace GymManagementSystem_API.Services.Abstracts
{
    public interface ILogInService
    {
        Task<CreateManagerDTO> ManagerLogIn(CreateManagerDTO managaer);
        Task<Entity.Member> MemberSignUp(CreateMemberDTO member);
        Task<LogInMemberDTO> MemberLogIn(LogInMemberDTO member);
    }
}
