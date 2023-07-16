using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AuthorManager : IAuthorService
{
    IAuthorDal _authorDal;

    public AuthorManager(IAuthorDal authorDal)
    {
        _authorDal = authorDal;
    }

    public void AddT(Author t)
    {
        _authorDal.Insert(t);
    }

    public void DeleteT(Author t)
    {
        _authorDal.Delete(t);
    }

    public void UpdateT(Author t)
    {
        _authorDal.Update(t);
    }

    public List<Author> GetList()
    {
        return _authorDal.GetListAll();
    }

    public Author GetById(int id)
    {
        return _authorDal.GetById(id);
    }

    public List<Author> GetAuthorById(int id)
    {
        return _authorDal.GetListAll(x => x.AuthorId == id);
    }
}