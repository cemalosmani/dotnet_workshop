using MassTransit;
using Shared;

namespace Stock.Api.Consumers;

public class OrderCreatedEventConsumer : IConsumer<OrderCreatedEvent>
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public OrderCreatedEventConsumer(IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider)
    {
        _publishEndpoint = publishEndpoint;
        _sendEndpointProvider = sendEndpointProvider;
    }

    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        int quantity = 0;
        foreach (var item in context.Message.Order.OrderItems)
        {
            quantity += item.Quantity;
        }

        if (quantity > 10)
        {
            //stock is not enough
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new System.Uri($"queue:{RabbitMQConstants.StockInsufficientQueueName}"));
            await sendEndpoint.Send(new StockInsufficientEvent
            {
                Order = context.Message.Order
            });
        }
        else
        {
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new System.Uri($"queue:{RabbitMQConstants.StockSufficientQueueName}"));
            await sendEndpoint.Send(new StockSufficientEvent
            {
                Order = context.Message.Order
            });
            //make payment
        }
    }
}