using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class SkillManager : ISkillService
{
    private readonly ISkillDal _skillDal;

    public SkillManager(ISkillDal skillDal)
    {
        _skillDal = skillDal;
    }

    public void AddT(Skill t)
    {
        _skillDal.Insert(t);
    }

    public void DeleteT(Skill t)
    {
        _skillDal.Delete(t);
    }

    public void UpdateT(Skill t)
    {
        _skillDal.Update(t);
    }

    public List<Skill> GetList()
    {
        return _skillDal.GetListAll();
    }

    public Skill GetById(int id)
    {
        return _skillDal.GetById(id);
    }
}