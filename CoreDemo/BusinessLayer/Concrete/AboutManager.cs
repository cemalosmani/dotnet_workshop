using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AboutManager : IAboutService
{
    IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public void AddT(About t)
    {
        throw new NotImplementedException();
    }

    public void DeleteT(About t)
    {
        throw new NotImplementedException();
    }

    public void UpdateT(About t)
    {
        throw new NotImplementedException();
    }

    public List<About> GetList()
    {
        return _aboutDal.GetListAll();
    }

    public About GetById(int id)
    {
        throw new NotImplementedException();
    }
}