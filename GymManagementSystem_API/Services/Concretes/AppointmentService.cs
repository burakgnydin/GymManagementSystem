using AutoMapper;
using GymManagementSystem_API.DatabaseContext;
using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;
using GymManagementSystem_API.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem_API.Services.Concretes
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AppointmentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<CreateAppointmentDTO> CreateAppointment(CreateAppointmentDTO appointment)
        {
            var map = _mapper.Map<CreateAppointmentDTO, Appointment>(appointment);
            map.Createddate = DateTime.Now;
            map.Modifieddate = DateTime.Now;
            var addedObj = _context.Appointments.Add(map);
            var response = _mapper.Map<Appointment, CreateAppointmentDTO>(addedObj.Entity);
            await _context.SaveChangesAsync();
            return response;
        }
        Task<EditAppointmentDTO> IAppointmentService.GetAppointmentByIdAsync(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);
            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }
            var response = _mapper.Map<Appointment, EditAppointmentDTO>(appointment);
            return Task.FromResult(response);
        }
        public async Task<ServiceResponse<List<EditAppointmentDTO>>> GetAllAppointmentsAsync()
        {
            var appointments = await _context.Appointments.ToListAsync();

            var response = new ServiceResponse<List<EditAppointmentDTO>>();

            if (appointments.Count > 0)
            {
                response.Data = _mapper.Map<List<Appointment>, List<EditAppointmentDTO>>(appointments);
                response.Success = true;
                response.Message = "Appointments listed successfully!";
            }
            else
            {
                response.Data = new List<EditAppointmentDTO>();
                response.Success = false;
                response.Message = "No appointments found.";
            }

            return response;
        }

        public async Task<EditAppointmentDTO> UpdateAppointmentAsync(int id, EditAppointmentDTO appointment)
        {
            var existingAppointment = await _context.Appointments.FindAsync(id);
            if (existingAppointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }

            _mapper.Map(appointment, existingAppointment);
            existingAppointment.Modifieddate = DateTime.Now;

            await _context.SaveChangesAsync();

            var response = _mapper.Map<EditAppointmentDTO>(existingAppointment);
            return response;
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} was not found.");
            }
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}