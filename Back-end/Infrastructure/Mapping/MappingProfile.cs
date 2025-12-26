using AutoMapper;
using Back_end.Application.DTOs;
using Back_end.Domain.Entities;

namespace Back_end.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Brand, BrandDto>();
        CreateMap<Brand, BrandDetailDto>()
            .ForMember(dest => dest.Cars, opt => opt.MapFrom(src => src.Cars));
        CreateMap<CreateBrandDto, Brand>();
        CreateMap<UpdateBrandDto, Brand>();

        CreateMap<Feature, FeatureDto>();
        CreateMap<CreateFeatureDto, Feature>();
        CreateMap<UpdateFeatureDto, Feature>();

        CreateMap<Car, CarListDto>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));
        CreateMap<Car, CarDetailDto>()
            .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.CarFeatures));
        CreateMap<CarFeature, CarFeatureDto>()
            .ForMember(dest => dest.FeatureName, opt => opt.MapFrom(src => src.Feature.Name))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Feature.Category));

        CreateMap<User, UserDto>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));

        CreateMap<Role, RoleDto>();

        CreateMap<Order, OrderListDto>()
            .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => $"{src.Car.Brand.Name} {src.Car.Model}"))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email));
        CreateMap<Order, OrderDetailDto>()
            .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src.Car));
    }
}
