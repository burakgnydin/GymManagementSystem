using AutoMapper;
using AutoMapper.Execution;
using GymManagementSystem_API.DatabaseContext;
using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;
using GymManagementSystem_API.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

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
        public async Task<CreateManagerDTO> CreateManager(CreateManagerDTO manager)
        {
            var map = _mapper.Map<CreateManagerDTO, Manager>(manager);
            map.Createddate = DateTime.Now;
            map.Modifieddate = DateTime.Now;
            var addedObj = _context.Managers.Add(map);
            var response = _mapper.Map<Manager, CreateManagerDTO>(addedObj.Entity);
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<bool> DeleteMember(int id)
        {
            var result = _context.Members.Find(id);
            if (result != null)
            {
                _context.Members.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            throw new KeyNotFoundException($"Member with ID {id} was not found.");
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

        public async Task<List<Appointment>> GetMemberAppointments(int id, DateTime date)
        {
            var result = await _context.Appointments.Where(x => x.MemberId == id && x.Date == date).ToListAsync();
            if (result != null)
            {
                return result;
            }
            throw new KeyNotFoundException($"There is no appointment for this member with ID :{id}");
        }

        public async Task<Entity.Member> GetMemberById(int id)
        {
            var result = await _context.Members.FirstOrDefaultAsync(x => x.Id == id);
            ServiceResponse<List<Entity.Member>> _member = new ServiceResponse<List<Entity.Member>>();
            if (result != null)
            {
                _member.Success = true;
                return result;
            }
            throw new KeyNotFoundException($"There is no member with this ID :{id}");

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

        public Task SetMembershipPeriod(int id, int day)
        {
            var result = _context.Members.Find(id);
            if (result != null)
            {
                result.MembershipPeriod += day;
                _context.SaveChanges();
                return Task.FromResult(result.MembershipPeriod);
            }
            throw new KeyNotFoundException($"There is no member with this ID :{id}");
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

        
    }
}
