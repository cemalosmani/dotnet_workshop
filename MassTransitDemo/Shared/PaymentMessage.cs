namespace Shared;

public class PaymentMessage
{
    public string CardName { get; set; }
    public string CVV { get; set; }
    public string ValidationDate { get; set; }
}