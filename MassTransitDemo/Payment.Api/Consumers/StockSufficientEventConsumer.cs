using MassTransit;
using Shared;

namespace Payment.Api.Consumers;

public class StockSufficientEventConsumer : IConsumer<StockSufficientEvent>
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public StockSufficientEventConsumer(IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider)
    {
        _publishEndpoint = publishEndpoint;
        _sendEndpointProvider = sendEndpointProvider;
    }

    public async Task Consume(ConsumeContext<StockSufficientEvent> context)
    {
        decimal balance = 5000;
        decimal totalPrice = 0;

        foreach (var item in context.Message.Order.OrderItems)
        {
            totalPrice += item.Price * item.Quantity;
        }

        if (totalPrice > balance)
        {
            await _publishEndpoint.Publish(new BalanceNotEnoughEvent() { Order = context.Message.Order });
            //balance is not enough
        }
        else
        {
            var sendEndpoint =
                await _sendEndpointProvider.GetSendEndpoint(
                    new System.Uri($"queue:{RabbitMQConstants.BalanceIsEnoughQueueName}"));
            await sendEndpoint.Send(new BalanceIsEnoughEvent() { Order = context.Message.Order });
            //balance is enough
        }
    }
}