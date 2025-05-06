using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;

namespace GymManagementSystem_API.Services.Abstracts
{
    public interface IAppointmentService
    {
        Task<CreateAppointmentDTO> CreateAppointment(CreateAppointmentDTO appointment);
        Task<EditAppointmentDTO> GetAppointmentByIdAsync(int id);
        Task<ServiceResponse<List<EditAppointmentDTO>>> GetAllAppointmentsAsync();
        Task<EditAppointmentDTO> UpdateAppointmentAsync(int id, EditAppointmentDTO appointment);
        Task<bool> DeleteAppointmentAsync(int id);
    }
}