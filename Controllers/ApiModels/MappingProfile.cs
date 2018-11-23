using AspNetCoreCourse.Data.Entities;
using AutoMapper;

namespace AspNeCoretCourse.Controllers.ApiModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeApiModel>();
            CreateMap<Model, ModelApiModel>();
        }
    }
}