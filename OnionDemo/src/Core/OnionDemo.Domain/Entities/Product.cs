using OnionDemo.Domain.Common;

namespace OnionDemo.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Value { get; set; }
    public int Quantity { get; set; }
}