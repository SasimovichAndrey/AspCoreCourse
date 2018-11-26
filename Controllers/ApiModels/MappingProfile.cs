using AspNetCoreCourse.Controllers.ApiModels;
using AspNetCoreCourse.Data.Entities;
using AutoMapper;
using System.Linq;

namespace AspNeCoretCourse.Controllers.ApiModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeApiModel>();
            CreateMap<Make, SimpleMakeApiModel>();
            CreateMap<Model, SimpleModelApiModel>();
            CreateMap<Feature, SimpleFeatureApiModel>();

            CreateMap<Vehicle, VehicleGetApiModel>()
                .ForMember(v => v.Make, opt => opt.MapFrom(src => src.Model.Make))
                .ForMember(v => v.Features, opt => opt.MapFrom(src => src.Features.Select(f => f.Feature)));

            CreateMap<CreateVehicleApiModel, Vehicle>()
                .ForMember(v => v.Features, opt => opt.MapFrom(src => src.FeaturesIds.Select(id => new VehicleFeature { FeatureId = id })));
        }
    }
}