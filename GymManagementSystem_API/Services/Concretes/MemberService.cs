using AutoMapper;
using AutoMapper.Execution;
using GymManagementSystem_API.DatabaseContext;
using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;
using GymManagementSystem_API.Services.Abstracts;
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
        public async Task<CreateMemberDTO> CreateMember(CreateMemberDTO member)
        {
            var map = _mapper.Map<CreateMemberDTO, Entity.Member>(member);
            map.Createddate = DateTime.Now;
            map.Modifieddate = DateTime.Now;
            var addedObj = _context.Members.Add(map);
            var response = _mapper.Map<Entity.Member, CreateMemberDTO>(addedObj.Entity);
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
            ServiceResponse<List<Entity.Member>> _member = new ServiceResponse<List<Entity.Member>>();

            if (result != null)
            {
                _member.Data = result;
                _member.Success = true;
                _member.Message = "Members listed !";
                return _member;
            }
            throw new KeyNotFoundException($"List of members was not found!");
        }

        public async Task<Entity.Member> GetMemberById(int id)
        {
            var result = await _context.Members.FirstOrDefaultAsync(x=>x.Id == id);
            return result;
        }

        public async Task<EditMemberDTO> UpdateMember(EditMemberDTO member)
        {
            var result = _context.Members.Find(member.Id);
            if (result != null)
            {
                var map = _mapper.Map<EditMemberDTO,Entity.Member>(member);
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
    }
}
