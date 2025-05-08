using AutoMapper;
using GymManagementSystem_API.DatabaseContext;
using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;
using GymManagementSystem_API.Services.Abstracts;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem_API.Services.Concretes
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MemberService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EditMemberInfoDTO> EditMemberInfo(EditMemberInfoDTO member)
        {
            var result = _context.Members.Find(member.Id);
            if (result != null)
            {
                var map = _mapper.Map<EditMemberInfoDTO, Entity.Member>(member);
                result.Age = map.Age;
                result.Weight = map.Weight;
                result.Height = map.Height;
                var response = _mapper.Map<Entity.Member, EditMemberInfoDTO>(map);
                await _context.SaveChangesAsync();
                return response;
            }
            throw new KeyNotFoundException($"There is no member with this ID :{member.Id}");
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

        public async Task<EditAppointmentDTO> CreateAppointment(EditAppointmentDTO appointment)
        {
            var map = _mapper.Map<EditAppointmentDTO, Appointment>(appointment);
            if (map.Status == true)
            {
                map.Createddate = DateTime.Now;
                map.Modifieddate = DateTime.Now;
                map.Status = false;
                map.Date = DateTime.Now;
                map.MemberId = appointment.MemberId;
                var addedObj = _context.Appointments.Add(map);
                var response = _mapper.Map<Appointment, EditAppointmentDTO>(addedObj.Entity);
                await _context.SaveChangesAsync();
                return response;
            }
            throw new Exception("This date is full");     
        }

        public async Task<bool> DeleteAppointmentAsync(GetAppointmentDto appointment)
        {
            var result = await _context.Appointments.FindAsync(appointment.Id);
            if (result != null)
            {
                _context.Appointments.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            throw new KeyNotFoundException($"Appointment with ID {appointment.Id} was not found.");
            
            
        }

        public async Task<EditMemberDTO> UpdateMember(EditMemberDTO member)
        {

            var result = _context.Members.Find(member.Id);
            if (result != null)
            {
                var map = _mapper.Map<EditMemberDTO, Entity.Member>(member);
                result.NameSurname = map.NameSurname;
                result.Password = map.Password;
                result.Email = map.Email;
                result.Modifieddate = DateTime.Now;
                var response = _mapper.Map<Entity.Member, EditMemberDTO>(map);
                await _context.SaveChangesAsync();
                return response;
            }
            throw new KeyNotFoundException($"There is no member with this ID :{member.Id}");
        }

        public async Task<UpdateWaterDTO> EditAmountOfWaterAsync(UpdateWaterDTO water)
        {
            var result = _context.Members.Find(water.Id);
            if (result != null)
            {
                var map = _mapper.Map<UpdateWaterDTO, Entity.Member>(water);
                result.AmountOfWater += water.AmountOfWater;
                var response = _mapper.Map<Entity.Member, UpdateWaterDTO>(map);
                await _context.SaveChangesAsync();
                return response;
            }
            throw new Exception();
        }
    }
}
