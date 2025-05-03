using GymManagementSystem_API.DTO;

namespace GymManagementSystem_API.Services.Abstracts
{
    public interface IMemberService
    {
        public Task<EditMemberDTO> UpdateMember(EditMemberDTO member);
    }
}