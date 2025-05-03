using AutoMapper;
using AutoMapper.Execution;
using GymManagementSystem_API.DTO;

namespace GymManagementSystem_API.MappingProfile
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entity.Manager,CreateMemberDTO>().ReverseMap();
        }
    }
}
