using AutoMapper;
using AutoMapper.Execution;
using GymManagementSystem_API.DTO;
using GymManagementSystem_API.Entity;

namespace GymManagementSystem_API.MappingProfile
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entity.Manager,CreateManagerDTO>().ReverseMap();
            CreateMap<Entity.Manager,EditManagerDTO>().ReverseMap();
            CreateMap<Entity.Member,CreateMemberDTO>().ReverseMap();
            CreateMap<Entity.Member, EditMemberDTO>().ReverseMap();
            CreateMap<Entity.Member, EditMemberInfoDTO>().ReverseMap();
            CreateMap<Entity.Member, LogInMemberDTO>().ReverseMap();
            CreateMap<Entity.Member, UpdateWaterDTO>().ReverseMap();
            CreateMap<Entity.Appointment, EditAppointmentDTO>().ReverseMap();
            CreateMap<ChooseTrainerDto, Entity.Trainer>().ReverseMap();
            CreateMap< CreateTrainerDto, Trainer >().ReverseMap();
            CreateMap<CreateAppointmentDto, Appointment>().ReverseMap();

        }
    }
}
