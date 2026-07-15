using AutoMapper;
using Ops.Application.DTOs.Product;
using Ops.Domain.Entities;

namespace Ops.Application.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Entity -> DTO
        CreateMap<Product, ProductDto>();

        // DTO -> Entity
        CreateMap<CreateProductDto, Product>();

        // DTO -> Existing Entity (Update)
        CreateMap<UpdateProductDto, Product>();

        // Patch DTO -> Existing Entity
        CreateMap<PatchProductDto, Product>()
            .ForAllMembers(options =>
                options.Condition((src, dest, srcMember) =>
                    srcMember != null));
    }
}