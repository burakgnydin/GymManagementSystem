﻿using AutoMapper;
using AutoMapper.Execution;
using GymManagementSystem_API.DatabaseContext;
using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;
using GymManagementSystem_API.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace GymManagementSystem_API.Services.Concretes
{
    public class ManagerService : IManagerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ManagerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteMember(GetMemberDto member)
        {
            var result = _context.Members.Find(member.Id);
            if (result != null)
            {
                _context.Members.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            throw new KeyNotFoundException($"Member with ID {member.Id} was not found.");
        }

        public async Task<ServiceResponse<List<Entity.Member>>> GetAllMembers()
        {
            var result = await _context.Members.ToListAsync();

            var response = new ServiceResponse<List<Entity.Member>>();

            if (result.Count > 0)
            {
                response.Data = result;
                response.Success = true;
                response.Message = "Members listed successfully!";
            }
            else
            {
                response.Data = result;
                response.Success = false;
                response.Message = "No members found.";
            }

            return response;
        }

        public async Task<ServiceResponse<Appointment>> GetAppointmentByIdAsync(GetAppointmentDto appointment)
        {
            var result = await _context.Appointments.FirstOrDefaultAsync(x => x.Id == appointment.Id);
            var response = new ServiceResponse<Entity.Appointment>();
            if (result != null)
            {
                response.Data= result;
                response.Success = true;
            }
            else
            {
                response.Message = "Appointment was not found";
                response.Success = false;
            }
            
            return response;
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


        public async Task<Entity.Member> GetMemberById(GetMemberDto member)
        {
            var result = await _context.Members.FirstOrDefaultAsync(x => x.Id == member.Id);
            ServiceResponse<List<Entity.Member>> _member = new ServiceResponse<List<Entity.Member>>();
            if (result != null)
            {
                _member.Success = true;
                return result;
            }
            throw new KeyNotFoundException($"There is no member with this Id :{member.Id}");

        }

        public async Task<Entity.Member> GetMemberByName(GetMemberDtoByNameDto member)
        {
            var result = await _context.Members.FirstOrDefaultAsync(x => x.NameSurname == member.NameSurname);
            ServiceResponse<List<Entity.Member>> _member = new ServiceResponse<List<Entity.Member>>();
            if (result != null)
            {
                _member.Success = true;
                return result;
            }
            throw new KeyNotFoundException($"There is no member with this name :{member.NameSurname}");

        }


        public Task<int> GetMemberCount()
        {
            var result = _context.Members.Count();
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (result != null)
            {
                return Task.FromResult(result);
            }
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            throw new KeyNotFoundException("There is no member");
        }

        public async Task SetMembershipPeriod(MemberShipDTO day)
        {
            var result = _context.Members.Find(day.Id);
            if (result != null)
            {
                result.MembershipPeriod += day.Day;
                await _context.SaveChangesAsync();
            }
            else
            throw new KeyNotFoundException($"There is no member with this ID :{day.Id}");
        }

        public async Task<EditManagerDTO> UpdateManager(EditManagerDTO manager)
        {
            var result = _context.Managers.Find(manager.Id);
            if (result != null)
            {
                var map = _mapper.Map<EditManagerDTO, Manager>(manager);
                result.NameSurname = map.NameSurname;
                result.Password = map.Password;
                result.Email = map.Email;
                result.Modifieddate = DateTime.Now;
                var response = _mapper.Map<Manager, EditManagerDTO>(map);
                await _context.SaveChangesAsync();
                return response;
            }
            throw new KeyNotFoundException($"There is no manager with this ID :{manager.Id}");
        }

        public async Task<ServiceResponse<int>> GetIdByEmailAsync(GetIdDto email)
        {
            var result = await _context.Members.FirstOrDefaultAsync(x => x.Email == email.Email);

            var response = new ServiceResponse<int>();
            if (result != null)
            { 
                response.Data = result.Id;
                response.Success = true;
                response.Message = "Id was founded";
            }
            else
            {
                response.Data = 0;
                response.Success = false;
                response.Message = "Id was not founded";
            }
            return response;

            
        }

        public async Task<ServiceResponse<CreateTrainerDto>> CreateTrainerAsync(CreateTrainerDto trainer)
        {
            var map = _mapper.Map<CreateTrainerDto, Trainer>(trainer);
            map.Createddate = DateTime.Now;
            map.Modifieddate = DateTime.Now;
            map.NameSurname = trainer.NameSurname;
            var addedObj = _context.Trainers.Add(map);
            var response_ = _mapper.Map<Trainer, CreateTrainerDto>(addedObj.Entity);
            await _context.SaveChangesAsync();
            var response = new ServiceResponse<CreateTrainerDto>();
            if (response_ != null)
            {  
                response.Success = true;
                response.Data = response_;
                response.Message = "Trainer created successfuly";
            }
            else
            {
                response.Success = false;
                response.Data = new CreateTrainerDto();
                response.Message = "Trainer could not create";
            }
            return response;
            
        }

        public async Task<ServiceResponse<bool>> DeleteTrainerAsync(GetTrainerDto trainer)
        {
            var result = await _context.Trainers.FindAsync(trainer.Id);
            var response = new ServiceResponse<bool>(); 
            if (result != null)
            {
                _context.Trainers.Remove(result);
                await _context.SaveChangesAsync();
                response.Message = "Trainer removed successfuly";
                response.Data = true;
                response.Success = true;
            }
            else
            {
                response.Message = "Trainer could not find";
                response.Data = false;
                response.Success = false;
            }
            return response;
        }
    }
}
