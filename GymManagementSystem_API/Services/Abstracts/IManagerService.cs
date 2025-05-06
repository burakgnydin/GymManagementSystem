using AutoMapper;
using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;

namespace GymManagementSystem_API.Services.Abstracts
{
    public interface IManagerService
    {
        Task<EditManagerDTO> UpdateManager(EditManagerDTO manager);
        Task<bool> DeleteMember(EditMemberDTO member);
        Task<ServiceResponse<List<Entity.Member>>> GetAllMembers();
        Task<Entity.Member> GetMemberById(EditMemberDTO member);
        Task<int> GetMemberCount();
        Task<EditAppointmentDTO> GetAppointmentByIdAsync(EditAppointmentDTO appointment);
        Task<ServiceResponse<List<EditAppointmentDTO>>> GetAllAppointmentsAsync();
        Task SetMembershipPeriod(MemberShipDTO day);
    }
}
