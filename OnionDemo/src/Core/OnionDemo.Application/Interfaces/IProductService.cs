using OnionDemo.Application.Dtos;

namespace OnionDemo.Application.Interfaces;

public interface IProductService
{
    Task<List<ProductViewDto>> GetAllProducts();
}