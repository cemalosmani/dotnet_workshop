using MediatR;
using OnionDemo.Application.Wrappers;

namespace OnionDemo.Application.Features.Queries.GetProductById;

public class GetProductByIdQuery: IRequest<ServiceResponse<GetProductByIdViewModel>>
{
    public Guid Id { get; set; }
}