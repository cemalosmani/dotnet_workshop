using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IAuthorService : IGenericService<Author>
{
    List<Author> GetAuthorById(int id);
}