using AutoMapper;
using GymManagementSystem_API.DatabaseContext;
using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;
using GymManagementSystem_API.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem_API.Services.Concretes
{
    public class LogInService : ILogInService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LogInService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CreateManagerDTO> ManagerLogIn(CreateManagerDTO manager)
        {
            var result = _mapper.Map<CreateManagerDTO, Manager>(manager);
            if (manager.Email == "admin@admin" && manager.Password == "admin")
            {
                _context.Managers.Add(result);
                await _context.SaveChangesAsync();
                return manager;
            }
            throw new Exception();

        }

        public async Task<LogInMemberDTO> MemberLogIn(LogInMemberDTO member)
        {
            var existingMember = await _context.Members
                .FirstOrDefaultAsync(x => x.Email == member.Email && x.Password == member.Password);

            if (existingMember == null)
            {
                throw new Exception("Invalid email or password");
            }
            var map = _mapper.Map<Entity.Member, LogInMemberDTO>(existingMember);
            return map;
        }


        public async Task<Entity.Member> MemberSignUp(CreateMemberDTO member)
        {
            var IsExist = _context.Members.FirstOrDefault(x => x.Email == member.Email);
            var result = _mapper.Map<CreateMemberDTO, Entity.Member>(member);

            if (IsExist != null)
            {
                throw new Exception("Please enter a different email");
            }
            result.NameSurname = member.NameSurname;
            result.Email = member.Email;
            result.Password = member.Password;
            result.Createddate = DateTime.Now;
            result.Modifieddate = DateTime.Now;
            _context.Members.Add(result);
            await _context.SaveChangesAsync();
            return result;
            
        }
    }
}
