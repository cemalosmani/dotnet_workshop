using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Order.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IPublishEndpoint _publishEndpoint; //Exchange
    private readonly ISendEndpointProvider _sendEndpointProvider; //Queue

    public OrderController(ILogger<OrderController> logger, ISendEndpointProvider sendEndpointProvider, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _sendEndpointProvider = sendEndpointProvider;
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(Shared.Order order)
    {
        var sendEndpoint = await 
            _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQConstants.OrderCreateQueueName}"));
        await sendEndpoint.Send(new OrderCreatedEvent
        {
            Order = order
        });
        return Ok();
    }
}