namespace Shared;

public class Order
{
    public string OrderId { get; set; }
    public string CustomerId { get; set; }
    public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    public PaymentMessage PaymentMessage { get; set; }
}