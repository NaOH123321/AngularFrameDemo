using AutoMapper;
using SampleAngular.Core.Entities;
using SampleAngular.Infrastructure.Resources;

namespace SampleAngular.App.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Sample, SampleResource>()
            //    .ForMember(dest => dest.UpdateTime, opt => opt.MapFrom(src => src.LastModified));
            //CreateMap<SampleResource, Sample>();
            //CreateMap<SampleAddResource, Sample>();
            //CreateMap<SampleUpdateResource, Sample>();
        }
    }
}