using AutoMapper;
using GymManagementSystem_API.DatabaseContext;
using GymManagementSystem_API.DTO;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem_API.Services.Concretes
{
    public class MemberService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MemberService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EditMemberDTO> UpdateMember(EditMemberDTO member)
        {

            var result = _context.Members.Find(member.Id);
            if (result != null)
            {
                var map = _mapper.Map<EditMemberDTO, Entity.Manager>(member);
                result.NameSurname = map.NameSurname;
                result.Password = map.Password;
                result.Email = map.Email;
                result.Modifieddate = DateTime.Now;
                var response = _mapper.Map<Entity.Manager, EditMemberDTO>(map);
                await _context.SaveChangesAsync();
                return response;
            }
            throw new KeyNotFoundException($"There is no member with this ID :{member.Id}");
        }
    }
}
