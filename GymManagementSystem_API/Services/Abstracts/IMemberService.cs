using GymManagementSystem_API.DTO;

namespace GymManagementSystem_API.Services.Abstracts
{
    public interface IMemberService
    {
        public Task<CreateMemberDTO> CreateMember(CreateMemberDTO member);
        public Task<EditMemberDTO> UpdateMember(EditMemberDTO member);
        public Task<EditMemberInfoDTO> EditMemberInfo(EditMemberInfoDTO member);
        //public Task<EditMemberInfoDTO> EditAmountOfWater(EditMemberInfoDTO member);
    }
}