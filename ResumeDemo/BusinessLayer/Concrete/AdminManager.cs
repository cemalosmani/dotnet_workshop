using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AdminManager : IAdminService
{
    private readonly IAdminDal _adminDal;

    public AdminManager(IAdminDal adminDal)
    {
        _adminDal = adminDal;
    }

    public void AddT(Admin t)
    {
        _adminDal.Insert(t);
    }

    public void DeleteT(Admin t)
    {
        _adminDal.Delete(t);
    }

    public void UpdateT(Admin t)
    {
        _adminDal.Update(t);
    }

    public List<Admin> GetList()
    {
        return _adminDal.GetListAll();
    }

    public Admin GetById(int id)
    {
        return _adminDal.GetById(id);
    }
}