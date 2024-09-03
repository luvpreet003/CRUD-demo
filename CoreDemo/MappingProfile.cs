using AutoMapper;
using CoreDemoModels;

namespace CoreDemoAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CoreDemoCore.Domain.Schools, SchoolsDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(y => y.Id));   // used when element names are different in two entities
            CreateMap<CoreDemoCore.Domain.Students, StudentsDTO>().ReverseMap();

        }
    }
}
