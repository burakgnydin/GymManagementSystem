using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;

namespace GymManagementSystem_API.Services.Abstracts
{
    public interface IMemberService
    {
        Task<CreateMemberDTO> CreateMember(CreateMemberDTO member);
        Task<EditMemberDTO> UpdateMember(EditMemberDTO member);
        Task<bool> DeleteMember(int id);
        Task<ServiceResponse<List<Entity.Member>>> GetAllMembers();
        Task<Entity.Member> GetMemberById(int id);
        Task<int> GetMemberCount();
        Task<List<Appointment>> GetMemberAppointments(int id, DateTime date);
        Task SetMembershipPeriod(int id, int day);
    }
}
