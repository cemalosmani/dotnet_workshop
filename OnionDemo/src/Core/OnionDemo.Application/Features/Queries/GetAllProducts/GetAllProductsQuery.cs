using AutoMapper;
using MediatR;
using OnionDemo.Application.Dtos;
using OnionDemo.Application.Interfaces.Repositories;
using OnionDemo.Application.Wrappers;

namespace OnionDemo.Application.Features.Queries.GetAllProducts;

public class GetAllProductsQuery: IRequest<ServiceResponse<List<ProductViewDto>>>
{


    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductViewDto>>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }


        public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAll();

            var viewModel = mapper.Map<List<ProductViewDto>>(products);

            return new ServiceResponse<List<ProductViewDto>>(viewModel);
        }
    }
}