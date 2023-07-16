using AutoMapper;
using MediatR;
using OnionDemo.Application.Interfaces.Repositories;
using OnionDemo.Application.Wrappers;

namespace OnionDemo.Application.Features.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<GetProductByIdViewModel>>
{
    IProductRepository productRepository;
    private readonly IMapper mapper;

    public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
    }

    public async Task<ServiceResponse<GetProductByIdViewModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.Id);
        var dto = mapper.Map<GetProductByIdViewModel>(product);

        return new ServiceResponse<GetProductByIdViewModel>(dto);
    }
}