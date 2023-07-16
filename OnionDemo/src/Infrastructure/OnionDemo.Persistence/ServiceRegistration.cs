using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application.Interfaces.Repositories;
using OnionDemo.Persistence.Context;
using OnionDemo.Persistence.Repositories;

namespace OnionDemo.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceRegistration(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("memoryDb"));

        services.AddTransient<IProductRepository, ProductRepository>();
    }
}