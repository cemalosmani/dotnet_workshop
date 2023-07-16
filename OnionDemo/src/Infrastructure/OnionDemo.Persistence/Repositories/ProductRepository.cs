using OnionDemo.Application.Interfaces.Repositories;
using OnionDemo.Domain.Entities;
using OnionDemo.Persistence.Context;

namespace OnionDemo.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext): base(dbContext)
    {

    }
}