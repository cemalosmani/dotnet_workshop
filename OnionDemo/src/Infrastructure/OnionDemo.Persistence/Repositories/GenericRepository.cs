using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Interfaces.Repositories;
using OnionDemo.Domain.Common;
using OnionDemo.Persistence.Context;

namespace OnionDemo.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext dbContext;

    public GenericRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<T>> GetAll()
    {
        return await dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(Guid id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }
}