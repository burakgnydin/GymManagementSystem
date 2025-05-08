using AutoMapper;
using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;

namespace GymManagementSystem_API.Services.Abstracts
{
    public interface IManagerService
    {
        Task<EditManagerDTO> UpdateManager(EditManagerDTO manager);
        Task<bool> DeleteMember(GetMemberDto member);
        Task<ServiceResponse<List<Entity.Member>>> GetAllMembers();
        Task<Entity.Member> GetMemberById(GetMemberDto member);
        Task<int> GetMemberCount();
        Task<GetAppointmentDto> GetAppointmentByIdAsync(GetAppointmentDto appointment);
        Task<ServiceResponse<int>> GetIdByEmailAsync(GetIdDto email);
        Task<ServiceResponse<List<EditAppointmentDTO>>> GetAllAppointmentsAsync();
        Task SetMembershipPeriod(MemberShipDTO day);
    }
}
