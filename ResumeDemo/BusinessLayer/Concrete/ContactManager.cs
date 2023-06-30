using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ContactManager : IContactService
{
    private readonly IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public void AddT(Contact t)
    {
        _contactDal.Insert(t);
    }

    public void DeleteT(Contact t)
    {
        _contactDal.Delete(t);
    }

    public void UpdateT(Contact t)
    {
        _contactDal.Update(t);
    }

    public List<Contact> GetList()
    {
        return _contactDal.GetListAll();
    }

    public Contact GetById(int id)
    {
        return _contactDal.GetById(id);
    }
}