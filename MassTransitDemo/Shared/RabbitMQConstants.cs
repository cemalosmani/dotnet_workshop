namespace Shared;

public class RabbitMQConstants
{
    public const string OrderCreateQueueName = "order-create-queue";
    public const string StockInsufficientQueueName = "stock-insufficient-queue";
    public const string StockSufficientQueueName = "stock-sufficient-queue";
    public const string BalanceIsEnoughQueueName = "payment-balance-is-enough-queue";
    public const string BalanceNotEnoughQueueName = "payment-balance-not-enough-queue";
}