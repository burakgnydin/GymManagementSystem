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
                result.Height = map.Height/100;
                var index = (result.Weight) / (result.Height * result.Height);
                if (index <= 18.5 )
                {
                    result.BodyType = "Zayif";
                }
                else if(index>18.5 && index <= 24.9 )
                {
                    result.BodyType = "Ortalama";
                }
                else
                {
                    result.BodyType = "Kilolu";
                }
                var response = _mapper.Map<Entity.Member, EditMemberInfoDTO>(map);
                await _context.SaveChangesAsync();
                return response;
            }
            throw new KeyNotFoundException($"There is no member with this ID :{member.Id}");
        }
        public async Task<ServiceResponse<List<EditAppointmentDTO>>> GetAllAppointmentsByIdAsync(GetAppointmentDto appointment)
        {
            var appointments = await _context.Appointments.Where(a => a.MemberId == appointment.Id).ToListAsync();

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

        public async Task<CreateAppointmentDto> CreateAppointment(CreateAppointmentDto appointment)
        {
            var map = _mapper.Map<CreateAppointmentDto, Appointment>(appointment);
            if (map.Status == true)
            {
                map.Createddate = DateTime.Now;
                map.Modifieddate = DateTime.Now;
                map.Status = false;
                map.Date = DateTime.Now;
                map.MemberId = appointment.MemberId;
                var addedObj = _context.Appointments.Add(map);
                var response = _mapper.Map<Appointment, CreateAppointmentDto>(addedObj.Entity);
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
                if(!string.IsNullOrWhiteSpace(member.NameSurname))
                    result.NameSurname = map.NameSurname;
                if (!string.IsNullOrWhiteSpace(member.Password))
                    result.Password = map.Password;
                if (!string.IsNullOrWhiteSpace(member.Email))
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
                result.AmountOfWater = water.AmountOfWater;
                var response = _mapper.Map<Entity.Member, UpdateWaterDTO>(map);
                await _context.SaveChangesAsync();
                return response;
            }
            throw new Exception();
        }

        public async Task<ServiceResponse<List<Trainer>>> GetAllTrainersAsync()
        {
            var trainers = await _context.Trainers.ToListAsync();
            var response = new ServiceResponse<List<Trainer>>();

            if (trainers.Count > 0)
            {
                response.Data = trainers;
                response.Success = true;
                response.Message = "Trainers listed";
            }
            else
            {
                response.Data = new List<Trainer>();;
                response.Success = false;
                response.Message = "No trainer found";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> ChooseTrainerAsync(ChooseTrainerDto trainer)
        {
            var resultTrainer = _context.Trainers.FirstOrDefault(x => x.Id == trainer.TrainerId);
            var resultAppointment = _context.Appointments.FirstOrDefault(x => x.Id == trainer.AppointmentId);
            var response = new ServiceResponse<bool>();


               if(resultTrainer != null && resultAppointment != null)
                {
                    resultAppointment.TrainerId = trainer.TrainerId;
                    resultTrainer.IsTraining = true;
                    response.Success = true;
                    response.Data = true;
                    response.Message = "The trainer was chosen successfully";
                    await _context.SaveChangesAsync();

            }
                else
                {
                    response.Data = false ;
                    response.Success = false;
                    response.Message = $"There is no trainer with this Id {trainer.TrainerId}";
                }
            return response;
            
        }

        public async Task<ServiceResponse<string>> GetBodyTypeAsync(GetMemberDto member)
        {
            var result = await _context.Members.FirstOrDefaultAsync(x => x.Id == member.Id);

            var response = new ServiceResponse<string>();

            if (result != null)
            {
                response.Data = result.BodyType;
                response.Success = true;
                response.Message = "Found";
            }
            else
            {
                response.Data = string.Empty;
                response.Success = false;
                response.Message = "Was not found";
            }
            return response;
        }
       
    }
}
