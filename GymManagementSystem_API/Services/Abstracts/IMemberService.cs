using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;

namespace GymManagementSystem_API.Services.Abstracts
{
    public interface IMemberService
    {
        Task<EditMemberDTO> UpdateMember(EditMemberDTO member);
        Task<EditMemberInfoDTO> EditMemberInfo(EditMemberInfoDTO member);
        Task<ServiceResponse<List<EditAppointmentDTO>>> GetAllAppointmentsByIdAsync(GetAppointmentDto appointment);
        Task<CreateAppointmentDto> CreateAppointment(CreateAppointmentDto appointment);
        Task<bool> DeleteAppointmentAsync(GetAppointmentDto appointment);
        Task<UpdateWaterDTO> EditAmountOfWaterAsync(UpdateWaterDTO water);
        Task<ServiceResponse<List<Trainer>>> GetAllTrainersAsync();
        Task<ServiceResponse<bool>> ChooseTrainerAsync(ChooseTrainerDto trainer); 
        Task<ServiceResponse<string>> GetBodyTypeAsync(GetMemberDto member);
    }
}
