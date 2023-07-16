using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class EducationManager : IEducationService
{
    private readonly IEducationDal _educationDal;

    public EducationManager(IEducationDal educationDal)
    {
        _educationDal = educationDal;
    }

    public void AddT(Education t)
    {
        _educationDal.Insert(t);
    }

    public void DeleteT(Education t)
    {
        _educationDal.Delete(t);
    }

    public void UpdateT(Education t)
    {
        _educationDal.Update(t);
    }

    public List<Education> GetList()
    {
        return _educationDal.GetListAll();
    }

    public Education GetById(int id)
    {
        return _educationDal.GetById(id);
    }
}