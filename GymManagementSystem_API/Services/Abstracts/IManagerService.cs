using AutoMapper;
using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;

namespace GymManagementSystem_API.Services.Abstracts
{
    public interface IManagerService
    {
        Task<CreateManagerDTO> CreateManager(CreateManagerDTO managear);
        Task<EditManagerDTO> UpdateManager(EditManagerDTO manager);
        Task<bool> DeleteMember(int id);
        Task<ServiceResponse<List<Entity.Member>>> GetAllMembers();
        Task<Entity.Member> GetMemberById(int id);
        Task<int> GetMemberCount();
        Task<List<Appointment>> GetMemberAppointments(int id, DateTime date);
        Task SetMembershipPeriod(int id, int day);
    }
}
