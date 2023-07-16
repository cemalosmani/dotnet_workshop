using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionDemo.Application.Features.Commands.CreateProduct;
using OnionDemo.Application.Features.Queries.GetAllProducts;
using OnionDemo.Application.Features.Queries.GetProductById;

namespace OnionDemo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllProductsQuery();
        return Ok(await mediator.Send(query));
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetProductByIdQuery() { Id = id };
        return Ok(await mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProductCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}