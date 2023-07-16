using AutoMapper;
using OnionDemo.Application.Features.Commands.CreateProduct;
using OnionDemo.Application.Features.Queries.GetProductById;

namespace OnionDemo.Application.Mapping;

public class GeneralMapping: Profile
{

    public GeneralMapping()
    {
        CreateMap<Domain.Entities.Product, Dtos.ProductViewDto>()
            .ReverseMap();

        CreateMap<Domain.Entities.Product, CreateProductCommand>()
            .ReverseMap();

        CreateMap<Domain.Entities.Product, GetProductByIdViewModel>()
            .ReverseMap();
    }

}