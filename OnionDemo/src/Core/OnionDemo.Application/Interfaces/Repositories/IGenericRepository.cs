using OnionDemo.Domain.Common;

namespace OnionDemo.Application.Interfaces.Repositories;

public interface IGenericRepository<T> where T: BaseEntity
{
    Task<List<T>> GetAll();

    Task<T> GetById(Guid id);

    Task<T> AddAsync(T entity);
}