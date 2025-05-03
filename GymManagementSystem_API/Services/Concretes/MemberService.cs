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

        //public Task<EditMemberInfoDTO> EditAmountOfWater(EditMemberInfoDTO member)
        //{
        //    var result = _context.Members.Find(member.Id);
        //    if (result != null)
        //    {
        //        var map = _mapper.Map<EditMemberInfoDTO, Entity.Member>(member);
        //        result.AmountOfWater += 100;
        //    }
        //}

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
