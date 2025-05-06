using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;

namespace GymManagementSystem_API.Services.Abstracts
{
    public interface IMemberService
    {
        Task<EditMemberDTO> UpdateMember(EditMemberDTO member);
        Task<EditMemberInfoDTO> EditMemberInfo(EditMemberInfoDTO member);
        Task<ServiceResponse<List<EditAppointmentDTO>>> GetAllAppointmentsAsync();
        Task<EditAppointmentDTO> CreateAppointment(EditAppointmentDTO appointment);
        Task<bool> DeleteAppointmentAsync(EditAppointmentDTO appointment);
        Task<UpdateWaterDTO> EditAmountOfWater(UpdateWaterDTO water);
    }
}
