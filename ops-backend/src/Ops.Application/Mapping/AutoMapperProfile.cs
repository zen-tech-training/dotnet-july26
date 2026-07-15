using AutoMapper;
using Ops.Application.DTOs.Product;
using Ops.Application.DTOs.User;
using Ops.Domain.Entities;

namespace Ops.Application.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Entity -> DTO
        CreateMap<Product, ProductDto>();
        CreateMap<User, UserDto>();

        // DTO -> Entity
        CreateMap<CreateProductDto, Product>();
        CreateMap<CreateUserDto, User>();

        // DTO -> Existing Entity (Update)
        CreateMap<UpdateProductDto, Product>();
        CreateMap<UpdateUserDto, User>();

        // Patch DTO -> Existing Entity
        CreateMap<PatchProductDto, Product>()
            .ForAllMembers(options =>
                options.Condition((src, dest, srcMember) =>
                    srcMember != null));

        CreateMap<PatchUserDto, User>()
            .ForAllMembers(options =>
                options.Condition((src, dest, srcMember) =>
                    srcMember != null));
    }
}