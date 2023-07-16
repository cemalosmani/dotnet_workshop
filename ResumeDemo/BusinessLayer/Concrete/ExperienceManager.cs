using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ExperienceManager : IExperienceService
{
    private readonly IExperienceDal _experienceDal;

    public ExperienceManager(IExperienceDal experienceDal)
    {
        _experienceDal = experienceDal;
    }

    public void AddT(Experience t)
    {
        _experienceDal.Insert(t);
    }

    public void DeleteT(Experience t)
    {
        _experienceDal.Delete(t);
    }

    public void UpdateT(Experience t)
    {
        _experienceDal.Update(t);
    }

    public List<Experience> GetList()
    {
        return _experienceDal.GetListAll();
    }

    public Experience GetById(int id)
    {
        return _experienceDal.GetById(id);
    }
}